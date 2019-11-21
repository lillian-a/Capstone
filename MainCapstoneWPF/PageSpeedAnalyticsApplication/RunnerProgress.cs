using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageSpeedAnalyticsApplication
{
    public partial class RunnerProgress : Form
    {
        /// <summary>boolean runCSV - set whether originates from run csv form</summary>
        public bool runCSV = false;
        /// <summary>int DEFAULT_STEP - default step amount for progress bar</summary>
        public const int DEFAULT_STEP = 5;
        
        /// <summary>Constructor</summary>
        public RunnerProgress()
        {
            InitializeComponent();
        }

        /// <summary>Process function</summary>
        /// <param name="urls">List of url strings to process</param>
        /// <param name="reportMethod">string report method of report type to return</param>
        /// <returns>Boolean true if ran</returns>
        public bool Process(List<string> urls, string reportMethod)
        {
            UpdateStatus(10, "Validating Urls...");
            List<string> validUrls = PageSpeedCalculations.CheckIfUrlsValid(urls);
            int num_urls = validUrls.Count;
            int method = PageSpeedCalculations.ConvertReportMethod(reportMethod);
            int method_step = (method <= 1) ? 10 : 20;
            List<PageSpeedEntity> desktopResults = new List<PageSpeedEntity>(validUrls.Count);
            List<PageSpeedEntity> mobileResults = new List<PageSpeedEntity>(validUrls.Count);
            int i = 0;
            List<PageSpeedEntity> results = new List<PageSpeedEntity>(2);
            UpdateStatus(10, "Running services on urls...");
            foreach (string s in validUrls)
            {
                PageSpeedService pageSpeedService = new PageSpeedService();
                results = pageSpeedService.RunProcessUrl(s);
                desktopResults.Add(results[0]);
                mobileResults.Add(results[1]);
                i++;
            }
            int num = (runCSV) ? 60 : 50;
            UpdateStatus(num, "Creating reports...");
            PageSpeedReport.CreateReports(urls, desktopResults, mobileResults, PageSpeedCalculations.ConvertReportMethod(reportMethod));
            UpdateStatus(method_step, "Reports Created...");
            RunnerProgressBar1.Value = 100;
            this.Close();
            return true;
        }
        /// <summary>Runs process for a CSV file</summary>
        /// <param name="fileName"></param>
        /// <param name="filePath"></param>
        /// <param name="reportMethod"></param>
        /// <returns></returns>
        public bool ProcessFromCSV(string fileName, string filePath, string reportMethod)
        {
            // get urls
            runCSV = true;
            List<string> urlsFromCSV = PageSpeedCalculations.ParseCSV(filePath);
            IncreaseBar(10);
            Process(urlsFromCSV, reportMethod);
            return true;
        }

        /// <summary>Loads RunnerProgress Form</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunnerProgress_Load(object sender, EventArgs e)
        {
            RunnerProgressBar1.Step = DEFAULT_STEP;
            RunnerProgressBar1.Value = 0;
            UpdateStatusLabel("Starting Process...");
        }

        /// <summary>Update status in ProgressBar for ProgressBar size and Status label</summary>
        /// <param name="amt">Amount to increase ProgressBar by</param>
        /// <param name="s">String to change status label to</param>
        private void UpdateStatus(int amt, string s)
        {
            IncreaseBar(amt);
            UpdateStatusLabel(s);
        }

        /// <summary>Increases the ProgressBar by the passed in amount</summary>
        /// <param name="amt">Integer amount to increase ProgressBar by</param>
        private void IncreaseBar(int amt)
        {
            int max = 100;
            int start = RunnerProgressBar1.Value;
            if (start + amt <= max)
                RunnerProgressBar1.Value = start + amt;
            else
                RunnerProgressBar1.Value = max;
        }
        /// <summary>Updates status label in form with passed in string</summary>
        /// <param name="s">string to change the label text to</param>
        private void UpdateStatusLabel(string s)
        {
            label1.Text = s;
        }
        
    }
}

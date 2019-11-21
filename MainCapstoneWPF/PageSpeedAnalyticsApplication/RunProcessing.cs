using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageSpeedAnalyticsApplication
{
    class RunProcessing
    {

        /// RunProcessingCSV
        /// <summary>Runs the procedures starting from the CSV form</summary>
        /// <param name="fileName">name of the csv file</param>
        /// <param name="filePath">path of the csv file</param>
        /// <param name="reportMethod">requested method for report</param>
        /// <returns></returns>
        public static bool RunProcessingCSV(string fileName, string filePath, string reportMethod)
        {
            List<string> urlsFromCSV = PageSpeedCalculations.ParseCSV(filePath);
            RunProcessingList(urlsFromCSV, reportMethod);
            return true;
        }
        
        /// RunProcessingList
        /// <summary>Run the procedure on a given list.</summary>
        /// <param name="urls">urls to run through the procedure.</param>
        /// <param name="reportMethod">requested method for report</param>
        /// <returns></returns>
        public static bool RunProcessingList(List<string> urls, string reportMethod)
        {
            List<string> validUrls = PageSpeedCalculations.CheckIfUrlsValid(urls);
            List<PageSpeedEntity> desktopResults = new List<PageSpeedEntity>(validUrls.Count);
            List<PageSpeedEntity> mobileResults = new List<PageSpeedEntity>(validUrls.Count);
            int i = 0;
            List<PageSpeedEntity> results = new List<PageSpeedEntity>(2);
            foreach (string s in validUrls)
            {
                PageSpeedService pageSpeedService = new PageSpeedService();
                results = pageSpeedService.RunProcessUrl(s);
                desktopResults.Add(results[0]);
                mobileResults.Add(results[1]);
                i++;
            }
            PageSpeedReport.CreateReports(urls, desktopResults, mobileResults, PageSpeedCalculations.ConvertReportMethod(reportMethod));
            return true;
        }
        
        public static void ShowStatusMsg(string msg)
        {
            var result = MessageBox.Show(msg, "Status Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}

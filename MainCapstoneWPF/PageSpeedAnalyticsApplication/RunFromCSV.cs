using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows;

namespace PageSpeedAnalyticsApplication
{
    public partial class RunFromCSV : Form
    {
        /// <summary>
        /// Global Variables:
        /// returnMethod - report method (set by user)
        /// fileNameToSubmit - File Name of CSV
        /// filePathToSubmit - File Path of CSV
        /// </summary>
        // Report Method - set by user
        string returnMethod;
        // File Name of CSV
        string fileNameToSubmit;
        // File Path of CSV
        string filePathToSubmit;
        // Default Report Method - if user does not select one.
        const string DEFAULT_RETURN_METHOD = "CSV";

        /// RunFromCSV
        /// <summary>Constructor</summary>
        public RunFromCSV()
        {
            InitializeComponent();
            returnMethod = DEFAULT_RETURN_METHOD;
            fileNameToSubmit = String.Empty;
            filePathToSubmit = String.Empty;
        }

        /// ChooseFileButton_Click
        /// <summary>See: http://www.wpf-tutorial.com/dialogs/the-openfiledialog/ </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChooseFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };
            string filename = "";
            string path = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fname in openFileDialog.FileNames)
                {
                    filename = Path.GetFileName(fname);
                    path = Path.GetFullPath(fname);
                }
            }
            UpdateFileNameLabel(filename, path);
            fileNameToSubmit = filename;
            filePathToSubmit = path;
        }

        /// UpdateFileNameLabel
        /// <summary>Updates the the CSVFileNameLabel</summary>
        /// <param name="f">file name string to display</param>
        /// <param name="p">file path string to display</param>
        private void UpdateFileNameLabel(string f, string p)
        {
            string s = "File: " + f + " ;\nPath: " + p;
            CSVFileNameLabel.Text = "File: " + f + " ;\nPath: " + p;
            // System.Windows.Forms.MessageBox.Show(s);
        }

        /// CSVGoButton_Click
        /// <summary></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CSVGoButton_Click(object sender, EventArgs e)
        {
            RunnerProgress runnerProgress = new RunnerProgress();
            bool responseReturned = runnerProgress.ProcessFromCSV(fileNameToSubmit, filePathToSubmit, returnMethod);
            // bool responseReturned = RunProcessing.RunProcessingCSV(fileNameToSubmit, filePathToSubmit, returnMethod);
            if (responseReturned == true)
            {
                if(returnMethod == "CSV")
                {
                    string msg = "Finished Processing.\n CSV File Located in Downloads Folder.";
                    ShowMessage(msg, "Information");
                }
                else
                {
                    ShowMessage("Finished Processing.", "Information");
                }
            }
            else
            {
                ShowMessage("Error Occured.", "Information");
            }
        }

        /// radioButton1_CheckedChanged
        /// <summary>Set returnMethod to CSV.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            returnMethod = "CSV";
        }

        /// radioButton2_CheckedChanged
        /// <summary>Set returnMethod to HTML.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            returnMethod = "HTML";
        }

        /// radioButton3_CheckedChanged
        /// <summary>Set returnMethod to BOTH.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            returnMethod = "BOTH";
        }

        /// HelpButton_Click
        /// <summary>Shows the Help message when Help Button is clicked.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            const string msg = "To Process a CSV File:\n" +
                "1. Click the 'SELECT FILE' button to select a csv file containing urls\n" +
                "2. Select from the available methods for the report to be given in\n" +
                "3. Click the 'Submit' button to begin processing\ns" +
                "Click the CANCEL Button to go back to the main screen.";
            const string caption = "Help";
            ShowMessage(msg, caption);
        }

        /// ShowMessage
        /// <summary>Uses MessageBox to show user a message.</summary>
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="btns"></param>
        /// <param name="icon"></param>
        private void ShowMessage(string message, string caption, 
                                MessageBoxButtons btns = MessageBoxButtons.OK,
                                MessageBoxIcon icon = MessageBoxIcon.Information)
        {
            DialogResult result;
            result = MessageBox.Show(message, caption, btns, icon);
        }

        /// RunFromCSV_FormClosed
        /// <summary>Open Welcome Form when current form is closed.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunFromCSV_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        /// RunFromCSVCancelButton_Click
        /// <summary>Closes form when Cancel Button is clicked.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunFromCSVCancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RunFromCSV_Load(object sender, EventArgs e)
        {

        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageSpeedAnalyticsApplication
{
    public partial class RunFromTxt : Form
    {
        // Report Method - set by user
        protected string returnMethod;
        // Default Report Method - if user does not select one.
        const string DEFAULT_RETURN_METHOD = "CSV";
        
        /// RunFromTxt
        /// <summary>Constructor</summary>
        public RunFromTxt()
        {
            InitializeComponent();
            returnMethod = DEFAULT_RETURN_METHOD;
        }
        
        /// SubmitButton_Click
        /// <summary>Starts procedure when Submit Button is clicked.
        /// <para>Gets the urls, starts RunnerProcess, gives applicable
        /// messages where needed.</para></summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            List<string> urls = GetUrlsFromTextBoxes();
            if (urls == null)
            {
                ShowMessage("No Urls Entered. Try Again.", "Information");
            }
            else
            {
                RunnerProgress runnerProgress = new RunnerProgress();
                // bool responseReturned = RunProcessing.RunProcessingList(urls, returnMethod);
                runnerProgress.Show();
                bool responseReturned = runnerProgress.Process(urls, returnMethod);
                if (responseReturned == true)
                {
                    if (returnMethod == "CSV")
                    {
                        string msg = "Finished Processing.\n CSV File saved in Downloads Folder.";
                        ShowMessage(msg, "Information");
                    }
                    ClearTextBoxes();
                }
                else
                {
                    ShowMessage("Error Occured.", "Information");
                }
            }
        }

        /// ClearTextBoxes
        /// <summary>Clears the textboxes on the form</summary>
        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        /// GetUrlsFromTextBoxes
        /// <summary>Gets url strings from the textboxes</summary>
        /// <returns>List of url strings</returns>
        private List<string> GetUrlsFromTextBoxes()
        {
            List<string> urlList = new List<string>();
            string url_1 = textBox1.Text;
            string url_2 = textBox2.Text;
            string url_3 = textBox3.Text;
            string url_4 = textBox4.Text;
            string url_5 = textBox5.Text;
            int count = 0;
            if (url_1 != string.Empty)
            {
                urlList.Add(url_1);
                count++;
            }
            if (url_2 != string.Empty)
            {
                urlList.Add(url_2);
                count++;
            }
            if (url_3 != string.Empty)
            {
                urlList.Add(url_3);
                count++;
            }
            if (url_4 != string.Empty)
            {
                urlList.Add(url_4);
                count++;
            }
            if (url_5 != string.Empty)
            {
                urlList.Add(url_5);
                count++;
            }
            if (count == 0)
                return null;
            return urlList;
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

        /// HelpButton_Click
        /// <summary>Shows the Help message when Help Button is clicked.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            const string msg = "To Process Urls:\n" +
                "1. Enter urls into text boxes provide (Max: 1 URL per TextBox)\n" +
                "2. Select from the available methods for the report to be given in\n" +
                "3. Click the 'Submit' button to begin processing\ns" +
                "Click the CANCEL Button to go back to the main screen.";
            const string caption = "Help";
            ShowMessage(msg, caption);
        }

        /// RunFromTxt_FormClosed
        /// <summary>Open Welcome Form when current form is closed.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunFromTxt_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        /// CancelButton_Click
        /// <summary>Closes form when Cancel Button is clicked.</summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

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
    public partial class Welcome : Form
    {
        /// <summary>
        /// Global Variables:
        /// RunFromTxt runFromTxtForm - form to use
        /// RunFromCSV runFromCSVForm - form to use
        /// </summary>
        private RunFromTxt runFromTxtForm;
        private RunFromCSV runFromCSVForm;

        /// <summary>
        /// Starts up the Welcome Form.
        /// </summary>
        public Welcome()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Welcome_Load(object sender, EventArgs e)
        {
            Console.WriteLine("Welcome Loading...");
        }

        /// <summary>
        /// Starts the Run From Text Form Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterURLButton_Click(object sender, EventArgs e)
        {
            //RunFromTxt runFromTxtForm = new RunFromTxt();
            runFromTxtForm = new RunFromTxt();
            runFromTxtForm.Show();
            runFromTxtForm.FormClosed += new FormClosedEventHandler(RunFromTxt_FormClosed);
            runFromTxtForm.Show();
            this.Hide();
        }

        /// <summary>
        /// Starts the Run From CSV Form Window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnterCSVButton_Click(object sender, EventArgs e)
        {
            //RunFromCSV runFromCSVForm = new RunFromCSV();
            runFromCSVForm = new RunFromCSV();
            runFromCSVForm.FormClosed += new FormClosedEventHandler(RunFromCSV_FormClosed);
            runFromCSVForm.Show();
            this.Hide();
            
        }

        /// <summary>
        /// Help Button - Shows the Help Message
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            const string msg = "Click CSV to process a csv file of urls\n Click Enter Urls to type in the urls.";
            const string caption = "Help";
            var result = MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Quit Button - Closes the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QuitButton_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        /// <summary>
        /// Opens the Welcome Form when the Run From CSV Form has closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunFromCSV_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
        }

        /// <summary>
        /// Opens the Welcome Form when the Run From Text Form has closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RunFromTxt_FormClosed(Object sender, FormClosedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
        }

    }
}

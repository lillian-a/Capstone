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
    /// <summary>
    /// Report HTML Viewer - Displays the HTML report file
    /// </summary>
    public partial class ReportHTMLViewer : Form
    {
        /// <summary>
        /// Global Variable:
        /// string htmlTextString - string of html text to show
        /// </summary>
        public string htmlTextString;

        /// <summary>
        /// Constructor.
        /// Sets the global htmlTextString variable
        /// Initializes the components
        /// </summary>
        /// <param name="htmlTextString"></param>
        public ReportHTMLViewer(string htmlTextString)
        {
            this.htmlTextString = htmlTextString;
            InitializeComponent();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        /// <summary>
        /// Loads up the WebBrowser Component. Sets the template file as the url and writes the passed in htmlTextString to the file.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReportHTMLViewer_Load(object sender, EventArgs e)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string tempHTMLFileLocation = path + @"\template.html";
            webBrowser1.ScriptErrorsSuppressed = true;
            // string tempHTMLFileLocation = @"C:\Users\Cat\source\repos\MainCapstoneWPF\PageSpeedAnalyticsApplication\template.html";
            webBrowser1.Url = new Uri(tempHTMLFileLocation);
            if (webBrowser1 != null)
            {
                HtmlDocument doc = webBrowser1.Document.OpenNew(true);
                doc.Write(htmlTextString);
            }
        }
    }
}

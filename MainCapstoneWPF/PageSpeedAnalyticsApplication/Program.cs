using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageSpeedAnalyticsApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Welcome());
        }

        //static void MainConsoleClassesTesting()
        //{
            //TestPageSpeedMainAPI();
            //TestingMethods.TestPageSpeedReportCreateCSV();
            //TestingMethods.TestArrayFunctions();
            //TestingMethods.TestParseCSVOfUrls();
            //TestingMethods.CSVUrlReadTest();
            //TestingMethods.TestingPageSpeedMainAPI();
            //TestingMethods.TestListCreation();
        //}
    }
}

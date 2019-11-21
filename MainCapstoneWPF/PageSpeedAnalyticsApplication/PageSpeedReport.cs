using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PageSpeedAnalyticsApplication
{
    class PageSpeedReport
    {
        /**
         * PATH NOTES FOR FILE SAVING
         * PATH NOTES FOR FILE SAVING
         * string s = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
         * // s = "C:\Users\Cat\Documents"
         * string s = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents","XYZ");
         * // s = "C:\Users\Cat\Documents\XYZ"
         * */

        /// CreateReports
        /// <summary>Runs create report processes</summary>
        /// <param name="urls">List of urls for report</param>
        /// <param name="deskResults">PageSpeedEntity List containing desktop results</param>
        /// <param name="mobileResults">PageSpeedEntity List containing mobile results</param>
        /// <param name="method">int indicating user's requested report method</param>
        public static void CreateReports(List<string> urls,
            List<PageSpeedEntity> deskResults,
            List<PageSpeedEntity> mobileResults, int method)
        {
            string[] header = GetHeaderStringExpanded();
            string[,] rows = new string[urls.Count + 1, (header.Length)];
            for (int i = 0; i < header.Length; i++)
            {
                rows[0, i] = header[i];
            }
            int rowIndex = 1;
            int listIndex = 0;
            foreach (string s in urls)
            {
                // Date
                rows[rowIndex, 0] = DateTime.Today.ToString("d");
                // url
                rows[rowIndex, 1] = urls[listIndex];
                // title
                if (deskResults[listIndex].Result.Title == null || deskResults[listIndex].Result.Title == "")
                {
                    rows[rowIndex, 2] = "";
                }
                else
                {
                    rows[rowIndex, 2] = deskResults[listIndex].Result.Title;
                }
                if (deskResults[listIndex].Result.ResponseCode == null && mobileResults[listIndex].Result.ResponseCode == null)
                {
                    rows[rowIndex, 3] = "NA";
                }
                else
                {
                    rows[rowIndex, 3] = deskResults[listIndex].Result.ResponseCode.ToString();
                }
                rows[rowIndex, 4] = deskResults[listIndex].Score.ToString();
                rows[rowIndex, 5] = deskResults[listIndex].Result.LoadingExperience.OverallCategory;
                rows[rowIndex, 6] = deskResults[listIndex].Result.LoadingExperience.Metrics["FIRST_CONTENTFUL_PAINT_MS"].Median.ToString();
                rows[rowIndex, 7] = deskResults[listIndex].Result.LoadingExperience.Metrics["FIRST_CONTENTFUL_PAINT_MS"].Category;
                rows[rowIndex, 8] = deskResults[listIndex].Result.LoadingExperience.Metrics["DOM_CONTENT_LOADED_EVENT_FIRED_MS"].Median.ToString();
                rows[rowIndex, 9] = deskResults[listIndex].Result.LoadingExperience.Metrics["DOM_CONTENT_LOADED_EVENT_FIRED_MS"].Category;
                rows[rowIndex, 10] = deskResults[listIndex].Result.PageStats.NumberResources.ToString();
                rows[rowIndex, 11] = deskResults[listIndex].Result.PageStats.NumberHosts.ToString();
                rows[rowIndex, 12] = deskResults[listIndex].Result.PageStats.TotalRequestBytes.ToString();
                rows[rowIndex, 13] = deskResults[listIndex].Result.PageStats.NumberStaticResources.ToString();
                rows[rowIndex, 14] = deskResults[listIndex].Result.PageStats.HtmlResponseBytes.ToString();
                rows[rowIndex, 15] = deskResults[listIndex].Result.PageStats.OverTheWireResponseBytes.ToString();
                rows[rowIndex, 16] = deskResults[listIndex].Result.PageStats.CssResponseBytes.ToString();
                rows[rowIndex, 17] = deskResults[listIndex].Result.PageStats.ImageResponseBytes.ToString();
                rows[rowIndex, 18] = deskResults[listIndex].Result.PageStats.JavascriptResponseBytes.ToString();
                rows[rowIndex, 19] = deskResults[listIndex].Result.PageStats.OtherResponseBytes.ToString();
                rows[rowIndex, 20] = deskResults[listIndex].Result.PageStats.NumberJsResources.ToString();
                rows[rowIndex, 21] = deskResults[listIndex].Result.PageStats.NumberCssResources.ToString();
                rows[rowIndex, 22] = deskResults[listIndex].Result.PageStats.NumTotalRoundTrips.ToString();
                rows[rowIndex, 23] = deskResults[listIndex].Result.PageStats.NumRenderBlockingRoundTrips.ToString();
                rows[rowIndex, 24] = deskResults[listIndex].Result.FormattedResults.RuleResults["AvoidLandingPageRedirects"].RuleImpact.ToString();
                rows[rowIndex, 25] = deskResults[listIndex].Result.FormattedResults.RuleResults["EnableGzipCompression"].RuleImpact.ToString();
                rows[rowIndex, 26] = deskResults[listIndex].Result.FormattedResults.RuleResults["LeverageBrowserCaching"].RuleImpact.ToString();
                rows[rowIndex, 27] = deskResults[listIndex].Result.FormattedResults.RuleResults["MainResourceServerResponseTime"].RuleImpact.ToString();
                rows[rowIndex, 28] = deskResults[listIndex].Result.FormattedResults.RuleResults["MinifyCss"].RuleImpact.ToString();
                rows[rowIndex, 29] = deskResults[listIndex].Result.FormattedResults.RuleResults["MinifyHTML"].RuleImpact.ToString();
                rows[rowIndex, 30] = deskResults[listIndex].Result.FormattedResults.RuleResults["MinifyJavaScript"].RuleImpact.ToString();
                rows[rowIndex, 31] = deskResults[listIndex].Result.FormattedResults.RuleResults["MinimizeRenderBlockingResources"].RuleImpact.ToString();
                rows[rowIndex, 32] = deskResults[listIndex].Result.FormattedResults.RuleResults["OptimizeImages"].RuleImpact.ToString();
                rows[rowIndex, 33] = deskResults[listIndex].Result.FormattedResults.RuleResults["PrioritizeVisibleContent"].RuleImpact.ToString();
                rows[rowIndex, 34] = mobileResults[listIndex].Score.ToString();
                rows[rowIndex, 35] = mobileResults[listIndex].Result.LoadingExperience.OverallCategory;
                rows[rowIndex, 36] = mobileResults[listIndex].Result.LoadingExperience.Metrics["FIRST_CONTENTFUL_PAINT_MS"].Median.ToString();
                rows[rowIndex, 37] = mobileResults[listIndex].Result.LoadingExperience.Metrics["FIRST_CONTENTFUL_PAINT_MS"].Category;
                rows[rowIndex, 38] = mobileResults[listIndex].Result.LoadingExperience.Metrics["DOM_CONTENT_LOADED_EVENT_FIRED_MS"].Median.ToString();
                rows[rowIndex, 39] = mobileResults[listIndex].Result.LoadingExperience.Metrics["DOM_CONTENT_LOADED_EVENT_FIRED_MS"].Category;
                rows[rowIndex, 40] = mobileResults[listIndex].Result.PageStats.NumberResources.ToString();
                rows[rowIndex, 41] = mobileResults[listIndex].Result.PageStats.NumberHosts.ToString();
                rows[rowIndex, 42] = mobileResults[listIndex].Result.PageStats.TotalRequestBytes.ToString();
                rows[rowIndex, 43] = mobileResults[listIndex].Result.PageStats.NumberStaticResources.ToString();
                rows[rowIndex, 44] = mobileResults[listIndex].Result.PageStats.HtmlResponseBytes.ToString();
                rows[rowIndex, 45] = mobileResults[listIndex].Result.PageStats.OverTheWireResponseBytes.ToString();
                rows[rowIndex, 46] = mobileResults[listIndex].Result.PageStats.CssResponseBytes.ToString();
                rows[rowIndex, 47] = mobileResults[listIndex].Result.PageStats.ImageResponseBytes.ToString();
                rows[rowIndex, 48] = mobileResults[listIndex].Result.PageStats.JavascriptResponseBytes.ToString();
                rows[rowIndex, 49] = mobileResults[listIndex].Result.PageStats.OtherResponseBytes.ToString();
                rows[rowIndex, 50] = mobileResults[listIndex].Result.PageStats.NumberJsResources.ToString();
                rows[rowIndex, 51] = mobileResults[listIndex].Result.PageStats.NumberCssResources.ToString();
                rows[rowIndex, 52] = mobileResults[listIndex].Result.PageStats.NumTotalRoundTrips.ToString();
                rows[rowIndex, 53] = mobileResults[listIndex].Result.PageStats.NumRenderBlockingRoundTrips.ToString();
                rows[rowIndex, 54] = mobileResults[listIndex].Result.FormattedResults.RuleResults["AvoidLandingPageRedirects"].RuleImpact.ToString();
                rows[rowIndex, 55] = mobileResults[listIndex].Result.FormattedResults.RuleResults["EnableGzipCompression"].RuleImpact.ToString();
                rows[rowIndex, 56] = mobileResults[listIndex].Result.FormattedResults.RuleResults["LeverageBrowserCaching"].RuleImpact.ToString();
                rows[rowIndex, 57] = mobileResults[listIndex].Result.FormattedResults.RuleResults["MainResourceServerResponseTime"].RuleImpact.ToString();
                rows[rowIndex, 58] = mobileResults[listIndex].Result.FormattedResults.RuleResults["MinifyCss"].RuleImpact.ToString();
                rows[rowIndex, 59] = mobileResults[listIndex].Result.FormattedResults.RuleResults["MinifyHTML"].RuleImpact.ToString();
                rows[rowIndex, 60] = mobileResults[listIndex].Result.FormattedResults.RuleResults["MinifyJavaScript"].RuleImpact.ToString();
                rows[rowIndex, 61] = mobileResults[listIndex].Result.FormattedResults.RuleResults["MinimizeRenderBlockingResources"].RuleImpact.ToString();
                rows[rowIndex, 62] = mobileResults[listIndex].Result.FormattedResults.RuleResults["OptimizeImages"].RuleImpact.ToString();
                rows[rowIndex, 63] = mobileResults[listIndex].Result.FormattedResults.RuleResults["PrioritizeVisibleContent"].RuleImpact.ToString();
                rowIndex++;
                listIndex++;
            }
            // CSV or BOTH
            if (method != 1)
            {
                CreateCSVReport(rows);
            }
            // HTML or BOTH
            if (method != 0)
            {
                CreateHTMLReport(rows);
            }
        }

        /// CreateReports
        /// <summary>Runs create report processes</summary>
        /// <param name="urls">List of urls for report</param>
        /// <param name="deskResults">PageSpeedEntity List containing desktop results</param>
        /// <param name="mobileResults">PageSpeedEntity List containing mobile results</param>
        /// <param name="method">int indicating user's requested report method</param>
        public static void CreateReportsOriginal(List<string> urls,
            List<PageSpeedEntity> deskResults,
            List<PageSpeedEntity> mobileResults, int method)
        {
            string[] header = GetHeaderString();
            string[,] rows = new string[urls.Count + 1, (header.Length)];
            for (int i = 0; i < header.Length; i++)
            {
                rows[0, i] = header[i];
            }
            int rowIndex = 1;
            int listIndex = 0;
            foreach (string s in urls)
            {
                // Date
                rows[rowIndex, 0] = DateTime.Today.ToString("d");
                // url
                rows[rowIndex, 1] = urls[listIndex];
                // title
                if (deskResults[listIndex].Result.Title == null || deskResults[listIndex].Result.Title == "")
                {
                    rows[rowIndex, 2] = "";
                }
                else
                {
                    rows[rowIndex, 2] = deskResults[listIndex].Result.Title;
                }
                rows[rowIndex, 3] = deskResults[listIndex].Score.ToString();
                rows[rowIndex, 4] = mobileResults[listIndex].Score.ToString();
                rows[rowIndex, 5] = deskResults[listIndex].Result.LoadingExperience.OverallCategory;
                rows[rowIndex, 6] = mobileResults[listIndex].Result.LoadingExperience.OverallCategory;
                rowIndex++;
                listIndex++;
            }
            // CSV or BOTH
            if (method != 1)
            {
                CreateCSVReport(rows);
            }
            // HTML or BOTH
            if (method != 0)
            {
                CreateHTMLReport(rows);
            }
        }

        /// GetHeaderString
        /// <summary>Create the string array for the header
        /// <para>Later can add more columns as needed</para></summary>
        /// <returns>headerStringArray - a string[] containing the header strings</returns>
        public static string[] GetHeaderString()
        {
            string[] headerStringArray = new string[7];
            headerStringArray[0] = "date";
            headerStringArray[1] = "url";
            headerStringArray[2] = "title";
            headerStringArray[3] = "desktop-score";
            headerStringArray[4] = "mobile-score";
            headerStringArray[5] = "desktop-overall-category";
            headerStringArray[6] = "mobile-overall-category";

            return headerStringArray;
        }

        /// GetHeaderString
        /// <summary>Create the string array for the header
        /// <para>Later can add more columns as needed</para></summary>
        /// <returns>headerStringArray - a string[] containing the header strings</returns>
        public static string[] GetHeaderStringExpanded()
        {
            int col_num = 64;
            string[] arr = new string[col_num];
            arr[0] = "date";
            arr[1] = "url";
            arr[2] = "title";
            arr[3] = "response_code";
            arr[4] = "d_score";
            arr[5] = "d_overall_category";
            arr[6] = "d_fcp_median";
            arr[7] = "d_fcp_category";
            arr[8] = "d_dcl_median";
            arr[9] = "d_dcl_category";
            arr[10] = "d_NumberResources";
            arr[11] = "d_NumberHosts";
            arr[12] = "d_TotalRequestBytes";
            arr[13] = "d_numberStaticResources";
            arr[14] = "d_htmlResponseBytes";
            arr[15] = "d_overTheWireResponseBytes";
            arr[16] = "d_cssResponseBytes";
            arr[17] = "d_imageResponseBytes";
            arr[18] = "d_javascriptResponseBytes";
            arr[19] = "d_OtherResponseBytes";
            arr[20] = "d_NumberJsResources";
            arr[21] = "d_NumberCssResources";
            arr[22] = "d_NumTotalRoundTrips";
            arr[23] = "d_NumRenderBlockingRoundTrips";
            arr[24] = "d_AvoidLandingPageRedirect";
            arr[25] = "d_EnableGzipCompression";
            arr[26] = "d_LeverageBrowserCaching";
            arr[27] = "d_MainResourceServerResponseTime";
            arr[28] = "d_MinifyCss";
            arr[29] = "d_MinifyHTML";
            arr[30] = "d_MinifyJavaScript";
            arr[31] = "d_MinimizeRenderBlockingResources";
            arr[32] = "d_OptimizeImages";
            arr[33] = "d_PrioritizeVisibleContent";
            arr[34] = "m_score";
            arr[35] = "m_overall_category";
            arr[36] = "m_fcp_median";
            arr[37] = "m_fcp_category";
            arr[38] = "m_dcl_median";
            arr[39] = "m_dcl_category";
            arr[40] = "m_NumberResources";
            arr[41] = "m_NumberHosts";
            arr[42] = "m_TotalRequestBytes";
            arr[43] = "m_numberStaticResources";
            arr[44] = "m_htmlResponseBytes";
            arr[45] = "m_overTheWireResponseBytes";
            arr[46] = "m_cssResponseBytes";
            arr[47] = "m_imageResponseBytes";
            arr[48] = "m_javascriptResponseBytes";
            arr[49] = "m_OtherResponseBytes";
            arr[50] = "m_NumberJsResources";
            arr[51] = "m_NumberCssResources";
            arr[52] = "m_NumTotalRoundTrips";
            arr[53] = "m_NumRenderBlockingRoundTrips";
            arr[54] = "m_AvoidLandingPageRedirect";
            arr[55] = "m_EnableGzipCompression";
            arr[56] = "m_LeverageBrowserCaching";
            arr[57] = "m_MainResourceServerResponseTime";
            arr[58] = "m_MinifyCss";
            arr[59] = "m_MinifyHTML";
            arr[60] = "m_MinifyJavaScript";
            arr[61] = "m_MinimizeRenderBlockingResources";
            arr[62] = "m_OptimizeImages";
            arr[63] = "m_PrioritizeVisibleContent";

            return arr;
        }

        /// CreateCSVReport
        /// <summary>
        /// <para>Takes in a multi-dimensional string array and creates a CSV
        /// file to contain it. Saves file to user's Downloads folder</para>
        /// </summary>
        /// <param name="data">multidimensional string array containing required data</param>
        public static void CreateCSVReport(string[,] data)
        {
            // Create CSV file name string using today's date & time
            string dateString = DateTime.Now.ToString("MMddyyyy-hhmmtt");
            string fileName = "PageSpeedCSVReport" + dateString + ".csv";
            string filePath = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Downloads",fileName);
            using (CsvFileWriter writer = new CsvFileWriter(filePath))
            {
                for (int row = 0; row < data.GetLength(0); row++)
                {
                    CsvRow csvRow = new CsvRow();
                    for (int col = 0; col < data.GetLength(1); col++)
                    {
                        csvRow.Add(data[row, col]);
                    }
                    writer.WriteRow(csvRow);
                }
            }
        }

        /// CreateHTMLReport
        /// <summary>
        /// <para>Takes in a multi-dimensional string array and creates an html
        /// file to show it.</para>
        /// </summary>
        /// <param name="data">multidimensional string array containing required data</param>
        public static void CreateHTMLReport(string[,] data)
        {
            // get html text
            string htmlText = CreateHtmlPage(data);
            // prints html text
            // MessageBox.Show(htmlText, "Status Update", MessageBoxButtons.OK, MessageBoxIcon.Question);
            // initialize and start report viewer html page
            ReportHTMLViewer reportHTMLViewer = new ReportHTMLViewer(htmlText);
            reportHTMLViewer.Show();
        }

        /// CreateHtmlPage
        /// <summary>Create text for a HTML file.</summary>
        /// <param name="data">multidimensional string array containing required data</param>
        /// <returns>String containing text of a newly created HTML page.</returns>
        public static string CreateHtmlPage(string[,] data)
        {
            // create file string
            string htmlString = "<html><head><title>Dashboard Template for Page Speed Project</title>";
            // add bootstrap css
            htmlString += "<link rel=\"stylesheet\" href=\"https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css\">";
            htmlString += "</head><body><center><h1>Latest Page Speed Performance Report</h1></center>";
            htmlString += "<center><p>Generated on: <span id=\"headingDateString\"></span></p></center><hr><h2>Details:</h2>";
            htmlString += "<div class=\"table - responsive\">";
            // get table
            string htmlTable = CreateHTMLTable(data);
            htmlString += htmlTable;
            // close table div
            htmlString += "</div>";
            // add jquery script
            htmlString += "<script src=\"https://code.jquery.com/jquery-3.2.1.slim.min.js\"></script>";
            // js date func
            htmlString += "<script type=\"text/javascript\">var d = new Date(); document.getElementById(\"headingDateString\").innerHTML = d.toDateString();</script>";
            htmlString += "</body></html>";
            return htmlString;
        }

        /// CreateHTMLTable
        /// <summary>Create text for a HTML table.</summary>
        /// <param name="data">multidimensional string array containing required data</param>
        /// <returns>String containing text of a newly created HTML Table.</returns>
        public static string CreateHTMLTable(string[,] data)
        {
            HtmlTable table = new HtmlTable();
            table.Attributes.Add("class", "table table-striped table-sm");
            for (int row = 0; row < data.GetLength(0); row++)
            {
                HtmlTableRow rows = new HtmlTableRow();
                for (int col = 0; col < data.GetLength(1); col++)
                {
                    HtmlTableCell cell = new HtmlTableCell();
                    cell.InnerHtml = data[row, col];
                    cell.Align = "Center";
                    rows.Cells.Add(cell);
                }
                table.Rows.Add(rows);
            }
            StringWriter writer = new StringWriter();
            Html32TextWriter htmlWriter = new Html32TextWriter(writer);
            table.RenderControl(htmlWriter);
            string htmlTableString = writer.ToString();
            return htmlTableString;
        }
    }
}

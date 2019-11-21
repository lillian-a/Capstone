using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml;

namespace PageSpeedAnalyticsApplication
{
    class SiteMapReader
    {
        public static void ReadSiteMap(string baseurl)
        {
            /* Create a new instance of the System.Net Webclient */
            WebClient wc = new WebClient();
            /* Set the Encodeing on the Web Client */
            wc.Encoding = System.Text.Encoding.UTF8;
            /* Download the document as a string*/
            string reply = wc.DownloadString(baseurl);
            /* Create a new xml document */
            XmlDocument urldoc = new XmlDocument();
            /* Load the downloaded string as XML */
            urldoc.LoadXml(reply);
            /*Create an list of XML nodes from the url nodes in the sitemap*/
            XmlNodeList xnList = urldoc.GetElementsByTagName("url");
            /*Loops through the node list and prints the values of each node*/
            foreach (XmlNode node in xnList)
            {
                Console.WriteLine("url " + node["loc"].InnerText);
                Console.WriteLine("priority " + node["priority"].InnerText);
                Console.WriteLine("last modified " + node["lastmod"].InnerText);
                Console.WriteLine("change frequency " + node["changefreq"].InnerText);
                Console.WriteLine(Environment.NewLine);
            }
        }

        // https://www.aubrett.com/article/information-technology/web-development/net-framework/csharp/read-sitemap-csharp
        public static XmlDocument SiteMapToXMLDoc(string baseurl)
        {
            // Create new xml document
            XmlDocument doc = new XmlDocument();
            // Create a new instance of the System.Net Webclient
            WebClient wc = new WebClient();
            // Set the Encodeing on the Web Client
            wc.Encoding = System.Text.Encoding.UTF8;
            // Download the document as a string
            string reply = wc.DownloadString(baseurl);
            // Load the downloaded string as XML
            doc.LoadXml(reply);
            return doc;
        }

        public static List<string> GetUrlsFromXmlDoc(XmlDocument doc)
        {
            List<string> urls = new List<string>();
            // Create an list of XML nodes from the url nodes in the sitemap
            XmlNodeList xnList = doc.GetElementsByTagName("url");
            // Loops through the node list and prints the values of each node
            foreach (XmlNode node in xnList)
            {
                urls.Add(node["loc"].InnerText);
            }

            return urls;
        }
    }
}

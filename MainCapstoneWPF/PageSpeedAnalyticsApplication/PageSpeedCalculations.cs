using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSpeedAnalyticsApplication
{
    class PageSpeedCalculations
    {
        /// GetAverageScore
        /// <summary>Returns the average of a given int array</summary>
        /// <param name="array">array of ints to average</param>
        /// <returns>Int value of the average of given ints.</returns>
        public int GetAverageScore(int[] array)
        {
            int sum = 0;
            foreach (int i in array)
                sum += i;
            return (sum / array.Length);
        }

        /// ParseCSV
        /// <summary>Parse a given CSV file for URLS to process
        /// <para>See: https://danashurst.com/parsing-a-csv-file/ </para></summary>
        /// <param name="path">Path to where CSV file is</param>
        /// <returns>List of strings containing urls from the parsed CSV file</returns>
        public static List<string> ParseCSV(string path)
        {
            List<string> parsedData = new List<string>();
            TextFieldParser parser = new TextFieldParser(path);
            parser.TextFieldType = FieldType.Delimited;
            parser.SetDelimiters(",");
            while (!parser.EndOfData)
            {
                string[] fields = parser.ReadFields();
                foreach (string field in fields)
                {
                    parsedData.Add(field);
                }
            }
            parser.Close();
            return parsedData;
        }
        
        /// CheckIfUrlsValid
        /// <summary>Loops through list of strings and check
        /// if they are valid urls; Returns only valid urls.</summary>
        /// <param name="urls">List of url strings to validate</param>
        /// <returns>List of strings containing validated urls</returns>
        public static List<string> CheckIfUrlsValid(List<string> urls)
        {
            List<string> listToReturn = new List<string>();
            foreach (string s in urls)
            {
                if (CheckURLIsValid(s))
                    listToReturn.Add(s);
            }
            return listToReturn;
        }

        /// CheckURLIsValid
        /// <summary>Loops through list of strings and check
        /// if they are valid urls; Returns only valid urls.</summary>
        /// <param name="strURL">string to validate</param>
        /// <returns>TRUE if string is valid url; else returns FALSE</returns>
        private static bool CheckURLIsValid(string strURL)
        {
            Uri uriResult;
            return Uri.TryCreate(strURL, UriKind.Absolute, out uriResult);
        }

        /// ConvertReportMethod
        /// <summary>Convert given int to a report method.</summary>
        /// <param name="s">string of return method</param>
        /// <returns>Int of converted report method</returns>
        public static int ConvertReportMethod(string s)
        {
            if (s == "CSV")
                return 0;
            else if (s == "HTML")
                return 1;
            else
                return 2;
        }
    }


    


}

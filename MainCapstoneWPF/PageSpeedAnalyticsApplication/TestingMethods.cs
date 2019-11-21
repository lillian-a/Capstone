using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageSpeedAnalyticsApplication
{
    class TestingMethods
    {
        public static void TestListCreation()
        {
            List<string> urlsToTest = new List<string>(2);
            urlsToTest.Add("https://github.com/");
            urlsToTest.Add("https://github.com/");
            //Program.RunProcessingList(urlsToTest, "CSV");
            RunProcessing.RunProcessingList(urlsToTest, "BOTH");
        }
        public static void TestArrayFunctions()
        {
            // Use Average to compute average value.
            double[] array1 = { 1, 2, 3, 5, 0 };
            double average1 = array1.Average();
            Console.WriteLine(average1);
            // Use Average to compute average string length.
            string[] array2 = { "dog", "cat", "perls" };
            double average2 = array2.Average(x => x.Length);
            Console.WriteLine(average2);

            Array stringArray = Array.CreateInstance(typeof(String), 6);
            stringArray.SetValue("Mango", 0);
            stringArray.SetValue("Orange", 1);
            stringArray.SetValue("Apple", 2);
            stringArray.SetValue("Grape", 3);
            stringArray.SetValue("Cherry", 4);
            stringArray.SetValue("WaterMelon", 4);
            Console.WriteLine("The Lower Bound of the Array : {0}", stringArray.GetLowerBound(0).ToString());
            Console.WriteLine("The Upper Bound of the Array : {0}", stringArray.GetUpperBound(0).ToString());

            int[] arrayA = new int[5];
            int lengthA = arrayA.Length;
            Console.WriteLine("Length of ArrayA : {0}", +lengthA);
            long longLength = arrayA.LongLength;
            Console.WriteLine("Length of the LongLength Array  : {0}", longLength);
            int[,] twoD = new int[5, 10];
            Console.WriteLine("The Size of 2D Array is : {0}", twoD.Length);

            int[] array3 = { 10, -10, -20, 0, 15, 20, 30 };
            Console.WriteLine("Maximum Element : " + array3.Max());
            Console.WriteLine("Minimum Element : " + array3.Min());

            int[] array = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int a in array)
                Console.WriteLine(a);
            Array.Reverse(array);
            Console.WriteLine("Reversed Array : ");
            foreach (int value in array)
                Console.WriteLine(value);

        }

        public static void TestParseCSVOfUrls()
        {
            // create string list object
            List<string> listOfURLs = new List<string>();
            // fill with url strings from ParseCSV Method
            listOfURLs = PageSpeedCalculations.ParseCSV(@"WriteTestUrls.csv");
            // print count - should be 2
            Console.WriteLine(listOfURLs.Count);
            // print each url string per line
            foreach (var el in listOfURLs)
                Console.WriteLine(el);
        }

        //public static void TestReportCSV()
        //{
        //    PageSpeedEntity pTest = new PageSpeedEntity();
        //    pTest.Base_URL = "https://www.google.com";
        //    pTest.Score = 90;
        //    PageSpeedReport.CreateCSVReport(pTest);
        //}

        //public static void TestPageSpeedMainAPI()
        //{
        //    Console.WriteLine("Page Speed Online API");
        //    try
        //    {
        //        new PageSpeedService().Run().Wait();
        //    }
        //    catch (AggregateException ex)
        //    {
        //        foreach (var e in ex.InnerExceptions)
        //        {
        //            Console.WriteLine("ERROR: " + e.Message);
        //        }
        //    }

        //    Console.WriteLine("Press any key to continue...");
        //    Console.ReadKey();
        //}

        public static void TestingPageSpeedMainAPI()
        {
            Console.WriteLine("Page Speed Online API");
            Console.WriteLine("=====================");
            PageSpeedService pageSpeedService = new PageSpeedService();
            pageSpeedService.RunProcessUrl("https://github.com/");
            PageSpeedEntity[] results = new PageSpeedEntity[2];
            //results = pageSpeedService.ServiceResults;

            Console.WriteLine("Press any key to continue...");
        }

        public static void CSVWriteTest()
        {
            // Write sample data to CSV file
            // /Users/Lillian/Projects/ReadWriteCsv/ReadWriteCsv/bin/Debug/WriteTest.csv
            using (CsvFileWriter writer = new CsvFileWriter("WriteTest.csv"))
            {
                for (int i = 0; i < 100; i++)
                {
                    CsvRow row = new CsvRow();
                    for (int j = 0; j < 5; j++)
                        row.Add(String.Format("Column{0}", j));
                    writer.WriteRow(row);
                }
            }
        }
        public static void CSVUrlReadTest()
        {
            // Read sample data from CSV file
            // using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
            using (CsvFileReader reader = new CsvFileReader("URLReachTest.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    foreach (string s in row)
                    {
                        Console.Write(s);
                        Console.Write(" ");
                        Console.Write(s.Contains(","));
                        Console.Write(" ");
                        Console.Write("***" + s + "***");
                        Console.Write(s.Contains(","));

                    }
                    Console.WriteLine();
                }
            }
        }

        public static void CSVReadTest()
        {
            // Read sample data from CSV file
            // using (CsvFileReader reader = new CsvFileReader("ReadTest.csv"))
            using (CsvFileReader reader = new CsvFileReader("WriteTest.csv"))
            {
                CsvRow row = new CsvRow();
                while (reader.ReadRow(row))
                {
                    foreach (string s in row)
                    {
                        Console.Write(s);
                        Console.Write(" ");
                        Console.Write(s.Contains(","));
                    }
                    Console.WriteLine();
                }
            }
        }
        public static void TestParseCSV()
        {
            List<string> urls = PageSpeedCalculations.ParseCSV("URLReachTest.csv");
            for (int i = 0; i < urls.Count; i++)
            {
                Console.WriteLine("{0}: {1}", i, urls[i]);
            }
        }
    }
}

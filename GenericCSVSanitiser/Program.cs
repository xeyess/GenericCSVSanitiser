using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ReverseGeocoding;

namespace GenericCSVSanitiser
{
    //Generic CSV Sanitiser
    //select lat and longt rows and filter
    class Program
    {
        //arguments
        // [0] *filename.csv : Target CSV file
        // [1] column(a,b,c) : select column a,b,c
        // [2] filter(location) : filter out by locations using offline reverse-geocoder

        private static void UpdateProgress(string s, int i)
        {
            //Console.Clear();

            if (i > 1)
            {
                Console.Write("\r" + s + ": " + i.ToString());
            }
            else
            {
                Console.Write(s + ": " + i.ToString());
            }
            //System.Threading.Thread.Sleep(1)
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("[CSV Sanitiser]");
                string rowName = "Latitude,Longitude";
                List<CsvContent> final = new List<CsvContent>();
                Console.WriteLine("Loading Required Files...");
                CsvLoader csl = new CsvLoader(args[0]);
                List<CsvContent> data = csl.CreateContent(args[1]);
                int i = 0;

                foreach(CsvContent csc in data)
                {
                    string output = csl.ReverseGeoCode(csc);
                    foreach (CityData cd in csl.Cities())
                    {
                        if(cd.Name == output)
                        {
                            if(cd.State == args[2])
                            {
                                final.Add(csc);
                            }
                        }
                    }
                    i++;
                    UpdateProgress("Filtering Files", i);
                }

                StreamWriter sw = new StreamWriter("output.csv");
                sw.WriteLine(rowName);
                foreach(CsvContent csc in final)
                {
                    sw.WriteLine(csc.lat + "," + csc.longt);
                }
                sw.Flush();
                sw.Close();
                Console.WriteLine("Complete.");
            }
            catch
            {
                Console.WriteLine("An error has occured. Please try again.");
            }
        }
        
    }
}

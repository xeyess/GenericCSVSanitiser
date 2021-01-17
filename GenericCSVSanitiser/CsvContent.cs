using ReverseGeocoding;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVSanitiser
{
    public class CsvLoader
    {
        private List<CityData> _cityData;
        private List<String> _data = new List<string>();
        private ReverseGeocoder rgeo;
        
        public CsvLoader(string fileName)
        {
            //Australian Cities DB
            StreamReader sr2 = new StreamReader(Environment.CurrentDirectory + "/cities/au_cities.csv");
            string data = sr2.ReadLine();
            string line2; //out category
            _cityData = new List<CityData>();
            while ((line2 = sr2.ReadLine()) != null)
            {
                String[] array = line2.Split(',');
                CityData c = new CityData(array[0], array[5]);
                _cityData.Add(c);
            }
            sr2.Close();

            //ReverseGeocode Cities DB (Geocites)
            rgeo = new ReverseGeocoder(Environment.CurrentDirectory + "/cities/cities1000.txt");
            StreamReader sr = new StreamReader(fileName);
            string columns = sr.ReadLine();
            string line;
            while((line = sr.ReadLine()) != null)
            {
                //handle strange artifacts
                if (line != "" || !line.Contains(",") || line == "," || String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
                {
                    _data.Add(line);
                }
            }
            sr.Close();

     
        }

        public List<CityData> Cities()
        {
            return _cityData;
        }

        public List<CsvContent> CreateContent(string row)
        {
            List<CsvContent> cscList = new List<CsvContent>();
            char[] strip = new char[3];
            strip[0] = '(';
            strip[1] = ')';
            strip[2] = '\'';
            string[] selectedRows = row.Split(strip);
            selectedRows = selectedRows[1].Split(',');
            int i = 0;
            foreach(string s in _data)
            {
                if(s != "" || s != null || s != ",")
                {
                   string[] rowData = s.Split(',');
                    if (rowData[0] != "")
                    {
                        cscList.Add(new CsvContent(rowData[Convert.ToInt32(selectedRows[0])], rowData[Convert.ToInt32(selectedRows[1])]));
                    }
                }
                i++;
            }
            return cscList;
        }

        public string ReverseGeoCode(CsvContent csc)
        {
            string location = rgeo.GetNearestPlaceName(Convert.ToDouble(csc.lat), Convert.ToDouble(csc.longt));
            //string location2 = rgeo.GetNearestPlace(Convert.ToDouble(csc.lat), Convert.ToDouble(csc.longt)).ToString();
            return location;
        }

    }

    

    public class CsvContent
    {
        public string lat;
        public string longt;

        public CsvContent(string lat, string longt)
        {
            this.lat = lat;
            this.longt = longt;
        }
    }
}

using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Newtonsoft.Json.Linq;

namespace Wololo
{
    class In
    {

        // Convert CSV file to JArray
        internal static JArray jarrFromCSVFile(string path)
        {
            JArray jarr = new JArray();
            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader))
            {
                var records = csv.GetRecords<dynamic>();

                foreach (dynamic rec in records)
                {
                    JObject job = JObject.FromObject(rec);

                    jarr.Add(job);
                }

            }
            return jarr;
        }

        // Convert HTTP url request to JArray

        // Convert JSON file to JArray 
        internal static JArray jarrFromJSONFile(string path)
        {
            string json = System.IO.File.ReadAllText(path);
            JArray jarr = JArray.Parse(json);
            return jarr;
        }

        // Convert C# OBJ to JArray 
        internal static JArray jarrFromObj(List<dynamic> objects)
        {
            // loop through the list of objects and add them to the array.
            JArray jarr = new JArray();

            foreach (dynamic obj in objects)
            {
                JObject job = JObject.FromObject(obj);
                jarr.Add(job);
            }
            return jarr;
        }
    }
}
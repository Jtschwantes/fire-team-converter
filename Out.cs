using System;
using System.IO;
using System.Dynamic;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CsvHelper;

namespace Wololo
{
    class Out
    {
        private static dynamic JobjToDynamic(dynamic jsonObject)
        {
            dynamic eobject = new ExpandoObject(); 
            var d = (IDictionary<String, Object>)eobject;

            foreach (var prop in jsonObject)
            {
                String value = "";
                if (prop.Value.ToString() == "")
                {
                    // any "null" in the JSON gets turned into a blank by default, so
                    // I switch it to the string "null" for readability in the csv
                    value = "null";
                }
                else
                {
                    // if the value is an array or object then csvwriter flips a biscuit.
                    // I remove all newline characters otherwise it breaks the csv syntax
                    value = prop.Value.ToString().Replace(System.Environment.NewLine, "");
                }

                d.Add(prop.Name, value);
            }

            return eobject;
        }

        private static List<dynamic> JsonToObj(dynamic inputJson) 
        {
            var collectedResults = new List<dynamic>();

            var deserializedJsonObject = Newtonsoft.Json.Linq.JToken.Parse(inputJson);
            
            if (deserializedJsonObject is Newtonsoft.Json.Linq.JArray)
            {
                foreach (var component in deserializedJsonObject) 
                {
                    collectedResults.Add(JobjToDynamic(component));
                }
            }
            else
            {
                collectedResults.Add(JobjToDynamic(deserializedJsonObject));
            }

            return collectedResults;
        }

        internal static void Csv (JArray data, string path)
        {
            using (var writer = new StreamWriter("sections.csv"))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteRecords(JsonToObj(data));
            }
        }
 
        internal static void Http (JArray data, string url)
        {
            throw new NotImplementedException();
        }

        internal static void Json (JArray data, string path)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(data));
        }

        internal static dynamic Object (JArray data)
        {

            return JsonToObj(data);
        }

        internal static void Console (JArray data)
        {
            System.Console.WriteLine(data.ToString());
        }
    }
}
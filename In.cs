using Newtonsoft.Json.Linq;

namespace Wololo
{
    class In
    {
        // Convert CSV file to JArray
        internal static JArray jarrFromCSVFile(string path)
        {
            JArray jarr = new JArray();
            return jarr;
        }

        // Convert HTTP url request to JArray
        internal static JArray jarrFromURL(string url)
        {
            JArray jarr = new JArray();
            return jarr;
        }


        // Convert JSON file to JArray 
        internal static JArray jarrFromJSONFile(string path)
        {
            JArray jarr = new JArray();
            return jarr;
        }

        // Convert C# OBJ to JArray 
        internal static JArray jarrFromObj(Object obj)
        {
            JArray jarr = new JArray();
            return jarr.FromObject(obj);
        }


    }
}
using System;
using Newtonsoft.Json.Linq;

namespace Wololo
{
    class Converter
    {
        //JArray data, center of the program
        public JArray jArray{get;set;}

        /********   In functions   ********
        * Takes data from somewhere ands
        * sets it to our JArray property.
        **********************************/
        //Data comes from a get request to a URL 
        public void HttpIn(string url)
        {
            string data = HttpGet(url);
            data = ToJsonArray(data);
            jArray = Parse(data);
        }

        //Data comes from a CSV fiele
        public void CsvIn(string path)
        {

        }

        //Data comes from a JSON file
        public void JsonIn(string path)
        {

        }

        //Data comes from a C# object
        public void ObjectIn(/* ??? */)
        {

        }

        /********  Out functions  *********
        * Takes the JSON data and outputs
        * it to somewhere.
        **********************************/
        // 
        public void HttpOut()
        {
            //Makes a post request with our JSON data
        }

        public void CsvOut()
        {

        }

        public void JsonOut()
        {

        }

        public void ObjectOut()
        {

        }

        public void ConsoleOut()
        {

        }
    }
}

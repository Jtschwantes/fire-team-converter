using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Wololo
{
    class Program
    {
        public static async Task<string> makeHttpRequest()
        {
            using(HttpClient client = new HttpClient())
            {
                try
                {
                    string token = Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    string response = await client.GetStringAsync("https://byui.instructure.com/api/v1/accounts/1/courses?by_subaccounts=25");
                    return response;
                }
                catch(HttpRequestException e)
                {
                    Console.WriteLine(e);
                    return e.ToString();
                }
            }
        }

        public static void Main()
        {
            var json = makeHttpRequest().Result;
            var converter = new Converter();
            JArray jArray = JArray.Parse(json);
            converter.jArray = jArray;
            converter.CsvOut("csv.csv.");

            // var converter = new Converter();
            // converter.CsvIn("csv.csv");
            // converter.JsonOut("json.json");
        }
    }
}
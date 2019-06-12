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
                    string response = await client.GetStringAsync("https://byui.instructure.com/api/v1/courses/96/modules?include[]=items");
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
            // Assignment Example
            var converter = new Converter();
            converter.jArray = converter.Parse(makeHttpRequest().Result);
            converter.CsvOut("csv.csv.");

            // CSV-JSON Example
            converter.CsvIn("csv.csv");
            converter.JsonOut("json.json");

            // JSON-Console Example
            converter.ConsoleOut();
        }
    }
}
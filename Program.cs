using System;
using System.Net.Http;
using System.Threading.Tasks;

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
                    // string token = Environment.GetEnvironmentVariable("CANVAS_API_TOKEN");
                    string token = System.IO.File.ReadAllText("devapikey.txt");

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
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
            // Assignment Example
            var converter = new Converter();
            converter.jArray = converter.Parse(makeHttpRequest().Result);
            converter.CsvOut("csv.csv.");

            // CSV-JSON Example
            converter.CsvIn("csv.csv");
            converter.JsonOut("json.json");

            // JSON-Console Example
            Console.WriteLine(converter.JsonStringOut());
        
        }
    }
}
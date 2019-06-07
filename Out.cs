using System;
using Newtonsoft.Json.Linq;
using CsvHelper;
using System.Dynamic;

namespace Wololo
{
    class Out
    {
        internal static void Csv (string path)
        {

        }
 
        internal static void Http (string url)
        {

        }

        internal static void Json (string path)
        {

        }

        internal static dynamic Object ()
        {
            return new ExpandoObject();
        }

        internal static string Console ()
        {
            return new String("wololo");
        }
    }
}
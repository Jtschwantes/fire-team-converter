﻿using System;
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
        //Data comes from a CSV fiele
        public void CsvIn(string path)
        {
            try
            {
                jArray = In.jarrFromCSVFile(path);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error getting data from CSV file:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //Data comes from a JSON file
        public void JsonIn(string path)
        {
            try
            {
                jArray = In.jarrFromURL(path);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error getting data from JSON file:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        //Data comes from a C# object
        public void ObjectIn(dynamic obj)
        {
            try
            {
                jArray = In.jarrFromObj(obj);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error getting data from Object:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /********  Out functions  *********
        * Takes the JSON data and outputs
        * it to somewhere.
        **********************************/
        public void CsvOut(string path)
        {
            try
            {
                Out.Csv(jArray, path);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error sending data to CSV file:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void JsonOut(string path)
        {
            try
            {
                Out.Json(jArray, path);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error sending data to JSON file:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public dynamic ObjectOut()
        {
            try
            {
                return Out.Object(jArray);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error returning object:");
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void ConsoleOut()
        {
            try
            {
                Out.Console(jArray);
            }
            catch(Exception e)
            {
                Console.WriteLine("Error printing object to console:");
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}

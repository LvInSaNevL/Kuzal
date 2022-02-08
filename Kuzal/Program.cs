using System;
using Newtonsoft.Json.Linq;

namespace Kuzal
{
    class Program
    {
        static void Main(string[] args)
        {
            // Error catching for cmd arguments
            string target = String.Empty;
            try { target = args[0]; }
            catch (IndexOutOfRangeException) {
                Console.WriteLine($"No file path given");
                Environment.Exit(0);
            }

            Console.WriteLine("Parsing input");
            JObject inputFile = Parser.Input(target);

            Console.WriteLine("Parsing Template");
            Page.Builder(inputFile);
        }
    }
}

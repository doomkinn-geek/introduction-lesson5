using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace additionalTask
{
    class Program
    {
        private static Dictionary<string, int> wordsCollection;
        static int Main(string[] args)
        {
            string inputFile = "", outputFile = "";
            if (args.Length == 0)
            {
                PrintArgumentsRequerments();
                return 1;
            }
            else
            {
                try
                {
                    inputFile = args[0];
                    outputFile = args[1];
                }
                catch(Exception)
                {
                    PrintArgumentsRequerments();
                    return 1;
                }                
            }

            wordsCollection = new Dictionary<string, int>();

            Console.WriteLine("Processing file...");            
            try
            {                
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding encoding = Encoding.GetEncoding("windows-1251");
                using (StreamReader sr = new StreamReader(inputFile, encoding)) //File.OpenText(inputFile))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {                        
                        Console.Write(".");
                        string[] strs = s.Split(' ');
                        for (int i = 0; i < strs.Length; i++)
                        {
                            string key = strs[i].Trim();
                            ParseString(key);
                        }
                    }
                    Console.WriteLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }           

            Console.WriteLine("Write result file...");
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Create(outputFile), Encoding.Unicode))
                {
                    foreach (KeyValuePair<string, int> entry in wordsCollection.OrderBy(key => key.Value))
                    {
                        sw.WriteLine($"{entry.Key}, {entry.Value}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return 1;
            }
            Console.WriteLine("Done!");

            return 0;
        }
        static void ParseString(string key)
        {
            if (wordsCollection == null) return;
            if (key != "")
            {
                if (!wordsCollection.ContainsKey(key))
                {
                    wordsCollection.Add(key, 1);
                    wordsCollection[key] = 1;
                }
                else
                {
                    wordsCollection[key]++;
                }
            }
        }

        static void PrintArgumentsRequerments()
        {
            Console.WriteLine("Invalid input arguments");
            Console.WriteLine("Usage: file.exe <input file> <output file>");
        }
    }
}

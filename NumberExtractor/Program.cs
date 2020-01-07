using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberExtractor
{
    class Program
    {
        /// <summary>
        /// Context of File
        /// </summary>
        private static string context = File.ReadAllText(@"C:\Users\faranam\Desktop\Exam\04 - Number Extractor\sampleText.txt");

        /// <summary>
        /// Address of Output File
        /// </summary>
        private static string secondDirectory = @"C:\Users\faranam\Desktop\NumberExtractor.txt";

        public static void NumberExtractor(string index)
        {
            string output = "";
            var matches = Regex.Matches(input: context, pattern: @"\d", options: RegexOptions.None);
            var numbers = new string[matches.Count];
            string cache = "";
            int temp;
            output = context;

            for (int i = 0; i < matches.Count; i++)
            {
                numbers[i] = matches[i].Value;
            }
            for (int i = 0; i < 20; i++)
            {

                temp = output.IndexOf(numbers[i].ToString());
                if (!output.StartsWith(numbers[i + 1]))
                {
                    cache += numbers[i];
                    cache += Environment.NewLine;
                }
                output = output.Remove(0, temp + 1);

                if (output.StartsWith(numbers[i + 1]))// || output.Substring(0, 1) == ".")
                {
                    cache += numbers[i + 1];
                    output = output.Remove(0, 1);
                    i++;
                }
                else
                    cache += Environment.NewLine;

            }
            Console.WriteLine(cache);
        }
        static void Main(string[] args)
        {
           // NumberExtractor(context);


            // Define a regular expression for repeated words.
            Regex rx = new Regex(@"\d{1,20}",

              RegexOptions.Compiled | RegexOptions.IgnoreCase);

            // Define a test string.        
            string Path =
                @"C:\Users\faranam\Desktop\Exam\04 - Number Extractor\sampleText.txt";
            StreamReader SR = new StreamReader(Path);
            var Lines = System.IO.File.ReadAllLines(Path);

            string NewPath = @"C:\Users\faranam\Desktop\Exam\04 - Number Extractor\Mary.txt";
            FileStream fs = File.Open(NewPath, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < Lines.Length; i++)
            {

                // Find matches.
                MatchCollection matches = rx.Matches(Lines[i].ToString());

                // Report on each match.
                foreach (Match match in matches)
                {
                    GroupCollection groups = match.Groups;
                    sw.WriteLine("{0} : {1}",
                                  match.Value,
                                  groups[0].Index);

                }

                Lines = File.ReadAllLines(Path);

            }

            sw.Close();
            fs.Close();
            Console.ReadKey();

            Console.ReadKey();
        }
    }
}

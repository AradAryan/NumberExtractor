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
        #region Fields
        /// <summary>
        /// Context of File
        /// </summary>
        private static string firstDirectory =
            @"C:\Users\faranam\Desktop\Exam\04 - Number Extractor\sampleText.txt";

        /// <summary>
        /// Address of Output File
        /// </summary>
        private static string secondDirectory =
            @"C:\Users\faranam\Desktop\NumberExtractor.txt";
        #endregion

        #region Nmuber Extractor
        /// <summary>
        /// Extracting Numbers
        /// </summary>
        public static void NumberExtractor()
        {
            Regex reGex = new Regex(
                @"\d{1,20}",
                RegexOptions.Compiled);
            FileStream file = File.Open(
               secondDirectory,
               FileMode.Append,
               FileAccess.Write);
            StreamReader streamReader = new StreamReader(firstDirectory);
            StreamWriter streamWriter = new StreamWriter(file);
            var Lines = File.ReadAllLines(firstDirectory);

            for (int i = 0; i < Lines.Length; i++)
            {
                MatchCollection matchesResult =
                    reGex.Matches(Lines[i].ToString());
                foreach (Match item in matchesResult)
                {
                    GroupCollection groupsCollection = item.Groups;
                    streamWriter.WriteLine($"{ item.Value} : { groupsCollection[0].Index}");
                }
                //var context = File.ReadAllLines(secondDirectory);
                streamWriter.Flush();
                file.Flush();
            }

            streamWriter.Close();
            file.Close();
        }
        #endregion

        #region Main Function
        /// <summary>
        /// Main Function
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            NumberExtractor();

            Console.WriteLine("Jobs Done!");
            Console.ReadKey();
        }
        #endregion
    }
}

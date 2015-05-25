using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParserProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            string patch = @"C:\Users\USer\LinesCounter\PLinesCounter\LinesCounter";
            Console.Write("Enter format: ");
            string format = Console.ReadLine();
            Console.WriteLine("Search ." + format + " files..");

            var dir = new DirectoryInfo(patch);// папка с файлами 
            var files = new List<string>(); // список для имен файлов 

            foreach (FileInfo file in dir.GetFiles("*." + format)) // извлекаем все файлы и кидаем их в список 
            {
                files.Add(file.FullName); // получаем полный путь к файлу и кидаем его в список 
                Console.WriteLine(file.FullName);
            }

            Console.WriteLine("Found: " + dir.GetFiles("*." + format).Count());


            for (int i = 0; i < dir.GetFiles("*." + format).Count(); i++)
            {
                string[] text = File.ReadAllLines(files[i]);

                int stringCount = 0;


                for (int j = 0; j < text.Length; j++)
                {
                    if (string.IsNullOrWhiteSpace(text[i]))
                    {
                        continue;
                    }

                    Regex rx = new Regex("([^//*]*[^/]*/|\\/\\/[^\\n]*)");
                    if (rx.IsMatch(text[i]))
                    {
                        continue;
                    }

                    stringCount++;
                }
                Console.WriteLine("In file: " + files[i] + ": " + (stringCount));
            }
            Console.ReadLine();
        }
    }
}

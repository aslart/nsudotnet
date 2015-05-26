using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;



namespace Sagyntay.nsudotnet.LinesCounter
{
    class LineCounter
    {
        private const string _extension = "*.cs";
        private const string _lineComment = "//";
        private const string _startComment = "/*";
        private const string _endComment = "*/";

        private static int CountPerDirectory(string directoryName, string fileExtension)
        {
            int localCount = 0;
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
            string extension = fileExtension == null ? _extension : fileExtension;
            FileInfo[] files = directoryInfo.GetFiles(extension);

            DirectoryInfo[] directories = directoryInfo.GetDirectories();

            Console.WriteLine("Traversing " + directoryName);
            foreach (FileInfo file in files)
            {
                localCount += CountPerFile(file.FullName);
            }
            foreach (DirectoryInfo directory in directories)
            {
                localCount += CountPerDirectory(directory.FullName, extension);
            }
            return localCount;
        }

        private static int CountPerFile(string fileName)
        {
            using (StreamReader reader = new StreamReader(fileName))
            {
                int lineCount = 0;
                bool commentActive = false;
                string line;
                Console.Write("Counting in " + fileName + ".. ");
                while ((line = reader.ReadLine()) != null)
                {
                    int lineComment = line.IndexOf(_lineComment);
                    if (lineComment >= 0)
                    {
                        line = line.Substring(0, lineComment);
                    }
                    if (!commentActive)
                    {
                        int startCommentPosition = line.IndexOf(_startComment);
                        if (startCommentPosition >= 0)
                        {
                            line = line.Substring(0, startCommentPosition);
                            commentActive = true;
                        }
                    }
                    else
                    {
                        int endCommentPosition = line.IndexOf(_endComment);
                        if (endCommentPosition >= 0)
                        {
                            if (endCommentPosition + 1 < line.Length)
                            {
                                line = line.Substring(endCommentPosition + 1);
                            }
                            else
                            {
                                line = "";
                            }
                            commentActive = false;
                        }
                        else
                        {
                            line = "";
                        }
                    }

                    line = line.Trim();

                    if (line.Length > 0)
                    {
                        lineCount++;
                    }
                }
                Console.WriteLine(lineCount);
                return lineCount;
            }
        }

        public static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Please enter extension");

                return;
            }

            string extension = args[0];
            string currentDirectory = Directory.GetCurrentDirectory();
            Console.WriteLine("We're starting from:" + currentDirectory);
            int result = LineCounter.CountPerDirectory(currentDirectory, extension);
            Console.WriteLine("Total line count:" + result);
            //Console.ReadKey();
          


        }
    }
}

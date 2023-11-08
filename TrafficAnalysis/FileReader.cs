using System;
using System.Collections.Generic;
using System.IO;

namespace TrafficAnalysis
{
    class FileReader
    {
        public static string[] ReadFileString(string filePath)
        {
            string[] fileLines = File.ReadAllLines(filePath);
            return fileLines;
        }

        public static int[] ReadFileInt(string filePath)
        {
            string[] fileLines = ReadFileString(filePath);
            int[] fileLinesConverted = new int[fileLines.Length];

            for (int i = 0; i < fileLines.Length; i++)
            {
                if (int.TryParse(fileLines[i], out fileLinesConverted[i]))
                {
                    // no error has occured, contuine
                }
                else
                {
                    Console.WriteLine($"Error with file formatting in file {filePath} on line {i + 1}");
                }
            }

            return fileLinesConverted;
        }
    }
}

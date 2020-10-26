using System;
using System.IO;
using System.Collections;

namespace append_date_filename
{
    public class Files
    {
          public static void ProcessDirectory(string targetDirectory, string date)
        {
            string [] fileEntries = Directory.GetFiles(targetDirectory);
            foreach(string fileName in fileEntries)
                ProcessFile(fileName, date);

            string [] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach(string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, date);
        }

        public static void ProcessFile(string path, string date)
        {
            var directoryArray = path.Split("\\");
            string fileName = directoryArray[directoryArray.Length-1];
            string firstWord = fileName.Split(".")[0].Split(" ")[0];
            DateTime dateValue;
           
           if (DateTime.TryParse(firstWord, out dateValue))
            {
                Console.WriteLine($"{fileName} contained a date, skipping.");
            }
            else
            {
                directoryArray[directoryArray.Length-1] = date + " " + fileName;
                string destinationPath = String.Join("\\", directoryArray);
                System.IO.File.Move(path, destinationPath);
            }
        }
    }
}

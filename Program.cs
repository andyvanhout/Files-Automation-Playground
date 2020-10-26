using System;
using System.IO;
using System.Collections;

namespace append_date_filename
{
    class Program
    {
        public static void Main(string[] args)
        {
                if (File.Exists(args[0]))
                {
                    Fileslogic.ProcessFile(args[0], args[1]);
                }
            
                else if (Directory.Exists(args[0]))
                {
                    Fileslogic.ProcessDirectory(args[0], args[1]);
                }
                else
                {
                    Console.WriteLine("{0} is not a valid file or directory.", args[0]);
                }
            Console.WriteLine("Finished writing missing dates.");
        }
    }
}

using System;
using System.IO;

namespace AdvendOfCode2k7_console
{
    class FileReader
    {
        string filename = null;
        string[] lines = null;

        FileReader()
        {

        }

        public static string[] readFile (string filename)
        {
            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines(filename);

            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR" + ex.Message);
            }

            return lines;
        }

    }
}

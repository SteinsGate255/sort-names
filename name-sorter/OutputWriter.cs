using System;
using System.Collections.Generic;
using System.IO; // Added to access File class
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class OutputWriter
    {
        /// <summary>
        /// Writes the list of names to the console.
        /// </summary>
        /// <param name="names">The list of names to write to the console.</param>
        public static void WriteNamesToConsole(List<string> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        /// <summary>
        /// Writes the list of names to a file.
        /// </summary>
        /// <param name="names">The list of names to write to the file.</param>
        /// <param name="filePath">The path of the file to write the names to.</param>
        public static void WriteNamesToFile(List<string> names, string filePath)
        {
            File.WriteAllLines(filePath, names); // Writes the list of names to the specified file path
        }
    }
}

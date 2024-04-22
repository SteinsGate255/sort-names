using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class FileReader
    {
        public static List<string> ReadNamesFromFile(string filePath)
        {
            // List to store names read from the file
            List<string> names = new List<string>();

            try
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Check if the file is empty
                if (lines.Length == 0)
                {
                    throw new Exception("File is empty.");
                }

                // Add each line (name) to the list
                foreach (string line in lines)
                {
                    names.Add(line.Trim()); // Trim any leading/trailing whitespace
                }
            }
            catch (Exception ex)
            {
                // Log and rethrow any exceptions
                Console.WriteLine($"Error reading file: {ex.Message}");
                throw; // Rethrow the exception
            }

            return names;
        }
    }
}

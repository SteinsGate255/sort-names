using name_sorter;
using System;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Check if the correct number of command line arguments is provided
        if (args.Length != 1)
        {
            Console.WriteLine("Expecting one text file path as input for name-sorter");
            return;
        }

        string inputFile = args[0];

        // Check if the input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine($"Error: Input file '{inputFile}' not found.");
            return;
        }

        // Read names from the input file
        List<string> nameStrings = FileReader.ReadNamesFromFile(inputFile);
        List<Name> names = new List<Name>();

        // Create Name objects
        foreach (string nameString in nameStrings)
        {
            string[] nameParts = nameString.Split(' ');

            if (nameParts.Length == 1)
            {
                // Single-word name, treat it as a given name
                names.Add(new Name("", nameParts));
                continue;
            }

            string lastName = nameParts.Last(); // Last word is always the last name

            // Determine given names
            string[] givenNames = nameParts.Take(nameParts.Length - 1).ToArray(); // All but the last word are given names
            Name name = new Name(lastName, givenNames);
            names.Add(name);
        }

        // Sort the names using LastName first then GivenNames Sort Strategy
        NameSorter nameSorter = new NameSorter(new LastNameThenGivenNamesSortStrategy());
        nameSorter.SortNames(names);

        List<string> name_Strings = new List<string>();
        foreach (Name name in names)
        {
            string fullName = $"{string.Join(" ", name.GivenNames)} {name.LastName}";
            name_Strings.Add(fullName);
        }

        // Write sorted names to console and file
        OutputWriter.WriteNamesToConsole(name_Strings);
        OutputWriter.WriteNamesToFile(name_Strings, "sorted-names-list.txt");
    }
}

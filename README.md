# Name Sorter
___________

This is a simple C# console application that sorts a list of names. Given a set of names, it orders them first by last name, then by any given names the person may have. The application assumes that a name must have at least one given name and may have up to three given names.


## Features
_________

- Sorts a list of names by last name and given names.
- Handles names with multiple given names.
- Supports names with given names of varying lengths.
- Sorts names consistently regardless of the order in which they are provided.
- Handles duplicate names correctly.
- Gracefully handles empty input and null names.


## Usage
______
To use the Name Sorter application, follow these steps:

### Clone the repository to your local machine.
1. Clone the repository to your local machine:
git clone https://github.com/SteinsGate255/sort-names.git
2. Open the solution in Visual Studio or your preferred C# IDE.
3. Build the solution to ensure all dependencies are resolved.
4. Navigate to the path containing the name-sorter application exe
5. Add/Replace the unsorted-names-list.txt in this path.
6. Run the application from this path on the terminal as such: .\name-sorter .\unsorted-names-list.txt
7. The sorted list of names will be displayed in the console and written to a file named sorted-names-list.txt.

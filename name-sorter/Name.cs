using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class Name
    {
        public string LastName { get; }  // Readonly property for last name
        public string[] GivenNames { get; }  // Readonly property for given names

        public Name(string lastName, string[] givenNames)
        {
            // Validation for null or empty last name
            if (lastName == null)
            {
                throw new ArgumentException("Last name cannot be null or empty.", nameof(lastName));
            }

            // Validation for null or empty given names array
            if (givenNames == null || givenNames.Length == 0)
            {
                throw new ArgumentException("Given names cannot be null or empty.", nameof(givenNames));
            }

            // Assigning values to properties
            this.LastName = lastName;
            this.GivenNames = givenNames;
        }

        
    }
}

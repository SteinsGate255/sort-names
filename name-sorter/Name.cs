using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class Name : IComparable<Name>
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

        public int CompareTo(Name other)
        {
            // Validation for null reference
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            // Compare last names first if both are not empty
            if (!string.IsNullOrEmpty(this.LastName) && !string.IsNullOrEmpty(other.LastName))
            {
                int lastNameComparison = string.Compare(this.LastName, other.LastName, StringComparison.OrdinalIgnoreCase);
                if (lastNameComparison != 0)
                {
                    return lastNameComparison;
                }
            }

            // If last names are equal or any one is empty, compare given names
            for (int i = 0; i < Math.Min(this.GivenNames.Length, other.GivenNames.Length); i++)
            {
                int givenNameComparison = string.Compare(this.GivenNames[i], other.GivenNames[i], StringComparison.Ordinal);
                if (givenNameComparison != 0)
                {
                    return givenNameComparison;
                }
            }

            // If all given names are equal, the names are considered equal
            return this.GivenNames.Length.CompareTo(other.GivenNames.Length);
        }
    }
}

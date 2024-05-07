using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public class LastNameThenGivenNamesSortStrategy : ISortStrategy
    {
        public void Sort(List<Name> names)
        {
            names.Sort((name1, name2) => CompareLastNames(name1, name2));
        }

        private int CompareLastNames(Name name1, Name name2)
        {
            // Compare last names first
            int lastNameComparison = string.Compare(name1.LastName, name2.LastName, StringComparison.OrdinalIgnoreCase);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }

            // If last names are the same, compare given names
            return CompareGivenNames(name1.GivenNames, name2.GivenNames);
        }

        private int CompareGivenNames(string[] givenNames1, string[] givenNames2)
        {
            // Compare given names alphabetically
            for (int i = 0; i < Math.Min(givenNames1.Length, givenNames2.Length); i++)
            {
                int comparison = string.Compare(givenNames1[i], givenNames2[i], StringComparison.OrdinalIgnoreCase);
                if (comparison != 0)
                {
                    return comparison;
                }
            }

            // If all given names are equal, compare based on the number of given names
            return givenNames1.Length.CompareTo(givenNames2.Length);
        }
    }

}

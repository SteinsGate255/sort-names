using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{

    public static class NameSorter
    {
        public static void SortNames(List<Name> names)
        {
            // Sort the list of names using the CompareTo method of the Name class
            if (names == null) throw new ArgumentNullException(nameof(names));
            names.Sort();
        }
    }

}

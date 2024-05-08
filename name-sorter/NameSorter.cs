using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    /// <summary>
    /// Class responsible for sorting a list of names using a specified sorting strategy.
    /// </summary>

    public class NameSorter
    {
        private readonly ISortStrategy _sortStrategy;

        /// <summary>
        /// Initializes a new instance of the <see cref="NameSorter"/> class with the specified sorting strategy.
        /// </summary>
        /// <param name="sortStrategy">The sorting strategy to be used.</param>

        public NameSorter(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        /// <summary>
        /// Sorts a list of names according to the specified sorting strategy.
        /// </summary>
        /// <param name="names">The list of names to be sorted.</param>

        public void SortNames(List<Name> names)
        {
            _sortStrategy.Sort(names);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    /// <summary>
    /// Interface for sorting strategies.
    /// </summary>
    public interface ISortStrategy
    {
        /// <summary>
        /// Sorts a list of names according to a specific strategy.
        /// </summary>
        /// <param name="names">The list of names to be sorted.</param>
        void Sort(List<Name> names);
    }
}

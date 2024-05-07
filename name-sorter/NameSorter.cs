using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{

    public class NameSorter
    {
        private readonly ISortStrategy _sortStrategy;

        public NameSorter(ISortStrategy sortStrategy)
        {
            _sortStrategy = sortStrategy;
        }

        public void SortNames(List<Name> names)
        {
            _sortStrategy.Sort(names);
        }
    }

}

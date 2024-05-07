using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace name_sorter
{
    public interface ISortStrategy
    {
        void Sort(List<Name> names);
    }
}

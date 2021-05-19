using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.ReaderSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SortSpace
{
    class SortReadersByKey : ISortLibrary
    {
        public void Sort(Manager manager)
        {
            var query = manager.ReaderList.OrderBy(r => r.ReaderKey);
            foreach (var q in query)
            {
                WriteLine(q);
            }
        }
    }
}

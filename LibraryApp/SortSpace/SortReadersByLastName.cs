using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SortSpace
{
    class SortReadersByLastName : ISortLibrary
    {
        public void Sort(Manager manager)
        {
            var query = manager.ReaderList.OrderBy(r => r.LastName);
            foreach (var q in query)   
            {
                WriteLine(q);
            }
        }
    }
}

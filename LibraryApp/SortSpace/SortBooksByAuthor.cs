using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SortSpace
{
    class SortBooksByAuthor : ISortLibrary
    {
        public void Sort(Manager manager)
        {
            var query = manager.BookList.OrderBy(book => book.BookAuthor);
            if (query.Count() > 0)
            {
                foreach(var item in query)
                {
                    WriteLine(item);
                }
            }
            else
            {
                WriteLine("Empty");
            }
        }
    }
}

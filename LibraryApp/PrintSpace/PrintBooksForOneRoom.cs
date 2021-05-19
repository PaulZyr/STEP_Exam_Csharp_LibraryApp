using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PrintSpace
{
    class PrintBooksForOneRoom
    {
        public void Print(Manager manager, int roomKey)
        {
            var query = manager.BookList.Where(book => book.RoomKey == roomKey).OrderBy(book => book.BookAuthor);

            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    WriteLine(item);
                }
            }
            else
            {
                WriteLine("Nothing to show");
            }
        }
    }
}

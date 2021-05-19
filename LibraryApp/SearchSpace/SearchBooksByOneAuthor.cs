using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;
using LibraryApp.InteractorSpace;

namespace LibraryApp.SearchSpace
{
    class SearchBooksByOneAuthor : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            string name = InteractorConsole.GetString("Input Author's Last Name: ");

            var query = from book in manager.BookList
                        where book.BookAuthor.Contains(name)
                        select book;

            if (query.Count() > 0)
            {
                WriteLine($"Found: {query.Count()} of {name}:");
                foreach (var item in query)
                {
                    WriteLine(item);
                }
            }
            else
            {
                WriteLine($"No books of {name}");
            }
        }
    }
}

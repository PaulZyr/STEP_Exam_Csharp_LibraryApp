using LibraryApp.ManagerSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.SearchSpace
{
    class SearchBooksByRating : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            var query = from b in manager.BookList
                        orderby b.Rating descending
                        select b;

            string str = InteractorConsole.GetString
                ("Y - Search only 20 first Rating Books\n" +
                "N - Search All Book by Rating\nInput (Y/N): ");
            int n;
            var i = 0;
            if (str.Contains('N'))
            {
                n = 20;
            }
            else
            {
                n = query.Count();
            }
            foreach(var item in query)
            {
                Console.WriteLine($"{item.Rating} || {item}");
                i++;
                if (i > n)
                {
                    break;
                }
            }
        }
    }
}

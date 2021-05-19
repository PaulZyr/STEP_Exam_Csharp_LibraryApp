using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.BookSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;

namespace LibraryApp.InvokerSpace
{
    class InvokerChangeBook
    {
        public void Change(Manager manager)
        {
            Clear();
            WriteLine("--- Change Book ---\n" +
                "1 - Input Book Key\n" +
                "2 - Show All Books\n" +
                "0 - Return\n");
            string str = ReadLine();
            if (str == "2")
            {
                WriteLine(manager.BookList);
            }
            else if (str == "0")
            {
                return;
            }
            int key = InteractorConsole.GetInt("Input Room Key");
            Book book = manager.BookList.FindByKey(key);
            if (book != null)
            {
                book = new BookChanger().Change(book);
            }
        }
    }
}

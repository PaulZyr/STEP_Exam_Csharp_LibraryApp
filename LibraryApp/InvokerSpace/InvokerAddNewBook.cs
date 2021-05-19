using LibraryApp.BookSpace;
using LibraryApp.ManagerSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InvokerSpace
{
    class InvokerAddNewBook
    {
        public void Add(Manager manager)
        {
            Book book = new BookCreator().Create();
            while (true)
            {
                if (book != null && manager.CheckNewBookValid(book))
                {
                    manager.BookList.Add(book);
                    break;
                }
                else
                {
                    Console.WriteLine("You need to change...");
                    book = new BookChanger().Change(book);
                }
            }
        }
    }
}

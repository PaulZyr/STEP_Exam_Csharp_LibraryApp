using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ReaderSpace;
using LibraryApp.BookSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.CollectionSpace;

namespace LibraryApp.PrintSpace
{
    class PrintReaderFullInfoByKey
    {
        public void Print(Manager manager, int readerKey)
        {
            Reader reader = manager.ReaderList.FindByKey(readerKey);

            if (reader != null)
            {
                WriteLine($"** {reader}\nBooks On Hand:\n");
                if (reader.OnHandBooks.Count() > 0)
                {
                    foreach(var item in reader.OnHandBooks)
                    {
                        Book tmp = manager.BookList.FindByKey(item);
                        if(tmp != null)
                        {
                            WriteLine(tmp);
                        }
                    }
                }
                else
                {
                    WriteLine("Nothing to show");
                }
            }
        }
    }
}

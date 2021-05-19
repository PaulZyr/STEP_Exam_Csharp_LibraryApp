using LibraryApp.ManagerSpace;
using LibraryApp.ReaderSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.PrintSpace
{
    class PrintReadersForOneRoom
    {
        public void Print(Manager manager, int roomKey)
        {
            var query = manager.ReaderList.Where(reader => reader.RoomKey == roomKey).OrderBy(reader => reader.LastName);

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

using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SortSpace
{
    class SortBooksByRoom : ISortLibrary
    {
        public void Sort(Manager manager)
        {
            foreach (var room in manager.RoomList)
            {
                var query = manager.BookList.Where(r => r.RoomKey == room.RoomKey).OrderBy(r => r.BookAuthor);

                WriteLine($"Room {room.RoomName}, key: {room.RoomKey}");
                if (query.Count() > 0)
                {
                    foreach (var q in query)
                    {
                        WriteLine(q);
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

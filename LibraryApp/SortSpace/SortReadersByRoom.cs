using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SortSpace
{
    class SortReadersByRoom : ISortLibrary
    {
        public void Sort(Manager manager)
        {
            foreach(var room in manager.RoomList)
            {
                var query = manager.ReaderList.Where(r => r.RoomKey == room.RoomKey).OrderBy(r => r.LastName);

                WriteLine($"Room {room.RoomName}, key: {room.RoomKey}");

                foreach(var q in query)
                {
                    WriteLine(q);
                }
            }
        }
    }
}

using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;
using LibraryApp.RoomSpace;
using LibraryApp.CollectionSpace;

namespace LibraryApp.PrintSpace
{
    class PrintOneRoomFullInfo
    {
        public void Print(Manager manager, Room room)
        {
            if (room != null)
            {
                WriteLine(room);
                if (room.OccupiedBy.Count() > 0)
                {
                    foreach (var item in room.OccupiedBy)
                    {
                        new PrintReaderFullInfoByKey().Print(manager, item);
                    }
                }
            }

        }

    }
}

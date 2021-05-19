using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;

namespace LibraryApp.SearchSpace
{
    class SearchRoomsByFreeSeats : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            var query = from room in manager.RoomList
                        where room.FreePlace() > 0
                        select room;

            if (query.Count() > 0)
            {
                WriteLine($"Rooms with free seats:");
                foreach (var item in query)
                {
                    WriteLine(item);
                }
            }
            else
            {
                WriteLine($"No free seats");
            }
        }
    }
}

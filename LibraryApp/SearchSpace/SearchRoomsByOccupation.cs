using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SearchSpace
{
    class SearchRoomsByOccupation : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            var query = from room in manager.RoomList
                        where room.OccupiedBy.Count() > 0
                        select room;

            if (query.Count() == 0)
            {
                WriteLine("All room are completely free");
            }
            else
            {
                foreach (var q in query)
                {
                    WriteLine(q);
                }
            }
        }
    }
}

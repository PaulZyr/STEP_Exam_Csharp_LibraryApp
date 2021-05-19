using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;

namespace LibraryApp.PrintSpace
{
    class PrintAllRoomsFullInfo
    {
        public void Print(Manager manager)
        {
            var query = manager.RoomList.OrderBy(r => r.RoomName);
            WriteLine("*** Library Rooms Full Info ***");

            if (query.Count() > 0)
            {
                foreach (var q in query)
                {
                    new PrintOneRoomFullInfo().Print(manager, q);
                }
            }
            else
            {
                WriteLine("Nothing to show");
            }
        }
    }
}

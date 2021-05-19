using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;
using LibraryApp.RoomSpace;
using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;

namespace LibraryApp.InvokerSpace
{
    class InvokerChangeRoom
    {
        public void Change(Manager manager)
        {
            Clear();
            WriteLine("--- Change Room ---\n" +
                "1 - Input Room Key\n" +
                "2 - Show All Rooms\n" +
                "0 - Return\n");
            string str = ReadLine();
            if (str == "2")
            {
                WriteLine(manager.RoomList);
            }
            else if (str == "0")
            {
                return;
            }
            int key = InteractorConsole.GetInt("Input Room Key");
            Room room = manager.RoomList.FindByKey(key);
            if (room != null)
            {
                room = new RoomChanger().Change(room);
            }
        }
    }
}

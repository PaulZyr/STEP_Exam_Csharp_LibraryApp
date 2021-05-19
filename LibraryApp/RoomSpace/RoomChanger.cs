using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.RoomSpace
{
    class RoomChanger
    {
        public Room Change(Room room)
        {
            while (true)
            {
                Clear();
                WriteLine(room);
                WriteLine("---  Change  ---\n" +
                    "1 - Room Key\n" +
                    "2 - Room Name\n" +
                    "3 - Room Capacity\n" +
                    "0 - Finish changing\n");
                string str = ReadLine();
                switch (str[0])
                {
                    case '1':
                        room.RoomKey = InteractorConsole.GetInt("Input Room Key: ");
                        break;
                    case '2':
                        room.RoomName = InteractorConsole.GetString("Input Room Name: ");
                        break;
                    case '3':
                        room.RoomCapacity = InteractorConsole.GetInt("Input Room Capacity: ");
                        break;
                    case '0':
                        return room;
                    default:
                        WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
}

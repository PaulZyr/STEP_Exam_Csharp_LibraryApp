using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.RoomSpace
{
    class RoomCreator
    {
        public Room Create()
        {
            Clear();
            Room room = new Room();

            room.RoomKey = InteractorConsole.GetInt("Input Room Key (number): ");

            Write("Input Book name: ");
            room.RoomName = InteractorConsole.GetString("Input Room Name: ");

            room.RoomCapacity = InteractorConsole.GetInt("Input Room Capacity: ");

            WriteLine("New Room: \n" + room);
            Write("Accept (y) or Change (n): ");
            string str = ReadLine();
            str = str.ToUpper();
            if (str == "Y" || str == "YES")
            {
                return room;
            }
            else
            {
                return new RoomChanger().Change(room);
            }
        }
    }
}

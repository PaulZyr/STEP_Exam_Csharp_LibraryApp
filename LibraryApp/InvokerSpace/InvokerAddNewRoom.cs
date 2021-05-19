using LibraryApp.ManagerSpace;
using LibraryApp.RoomSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InvokerSpace
{
    class InvokerAddNewRoom
    {
        public void Add(Manager manager)
        {
            Room room = new RoomCreator().Create();
            while (true)
            {
                if (room != null && manager.CheckNewRoomValid(room))
                {
                    manager.RoomList.Add(room);
                    break;
                }
                else
                {
                    Console.WriteLine("You need to change...");
                    room = new RoomChanger().Change(room);
                }
            }
        }
    }
}

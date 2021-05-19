using LibraryApp.ManagerSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InvokerSpace
{
    class InvokerChangeToUPPER
    {
        public void Change(Manager manager)
        {
            foreach (var item in manager.BookList)
            {
                item.BookAuthor = item.BookAuthor.ToUpper();
                item.BookName = item.BookName.ToUpper();
            }
            foreach (var item in manager.RoomList)
            {
                item.RoomName = item.RoomName.ToUpper();
            }
            foreach (var item in manager.ReaderList)
            {
                item.FirstName = item.FirstName.ToUpper();
                item.LastName = item.LastName.ToUpper();
                item.SecondName = item.SecondName.ToUpper();
            }
        }
    }
}

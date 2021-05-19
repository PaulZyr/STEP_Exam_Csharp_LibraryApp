using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ManagerSpace
{
    public static class ManagerExtention
    {
        public static void SaveDatabase(this Manager manager)
        {
            try
            {
                manager.BookList.Save(manager.BooksPath);
                manager.ReaderList.Save(manager.ReadersPath);
                manager.RoomList.Save(manager.RoomsPath);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Can't save Database:\n" + ex.Message);
            }
        }
    }
}

using LibraryApp.BookSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.ReaderSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.CollectionSpace
{
    public static class LibraryCollectionExtention
    {
        public static Book FindByKey(this LibraryCollection<Book> books, int key)
        {
            foreach (var item in books)
            {
                if (item.BookKey == key)
                {
                    return item;
                }
            }
            return null;
        }
        public static Reader FindByKey(this LibraryCollection<Reader> readers, int key)
        {
            foreach (var item in readers)
            {
                if (item.ReaderKey == key)
                {
                    return item;
                }
            }
            return null;
        }
        public static Room FindByKey(this LibraryCollection<Room> rooms, int key)
        {
            foreach (var item in rooms)
            {
                if (item.RoomKey == key)
                {
                    return item;
                }
            }
            return null;
        }
    }
}

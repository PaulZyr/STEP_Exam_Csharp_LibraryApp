using System;
using static System.Console;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.CollectionSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ReaderSpace;
using LibraryApp.BookSpace;

namespace LibraryApp.ManagerSpace
{
    public static class ManagerCheckExtention
    {
        public static bool CheckNewRoomValid(this Manager manager, Room room)
        {
            if (manager.RoomList.FindByKey(room.RoomKey) != null)
            {
                return false;
            }
            return true;
        }
        public static bool CheckRoomExists(this Manager manager, int roomKey)
        {
            if (manager.RoomList.FindByKey(roomKey) != null)
            {
                return true;
            }
            return false;
        }
        public static bool CheckRoomFreePlace(this Manager manager, int roomKey)
        {
            if (manager.CheckRoomExists(roomKey) 
                && manager.RoomList.FindByKey(roomKey).FreePlace() > 0)
            {
                return true;
            }
            return false;
        }
        public static bool CheckReaderExists(this Manager manager, int readerKey)
        {
            if (manager.ReaderList.FindByKey(readerKey) != null)
            {
                return true;
            }
            return false;
        }
        public static bool CheckNewReaderValid(this Manager manager, Reader reader)
        {
            if (manager.ReaderList.FindByKey(reader.ReaderKey) != null)
            {
                return false;
            }
            return true;
        }
        public static bool CheckReaderPermission
            (this Manager manager, int roomKey, int readerKey)
        {
            if (manager.CheckRoomExists(roomKey) && manager.CheckReaderExists(readerKey))
            {
                if (manager.ReaderList.FindByKey(readerKey).RoomKey == roomKey)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckReaderInRoom(this Manager manager, int roomKey, int readerKey)
        {
            if (manager.CheckRoomExists(roomKey) && manager.CheckReaderExists(readerKey))
            {
                if (manager.RoomList.FindByKey(roomKey).OccupiedBy.Contains(readerKey))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool CheckNewBookValid(this Manager manager, Book book)
        {
            if (manager.BookList.FindByKey(book.BookKey) != null 
                || manager.RoomList.FindByKey(book.RoomKey) == null)
            {
                return false;
            }
            return true;
        }
        public static bool CheckBooksReturned(this Manager manager, int readerKey)
        {
            if (manager.CheckReaderExists(readerKey)
                && manager.ReaderList.FindByKey(readerKey).OnHandBooks.Count() == 0)
            {
                return true;
            }
            return false;
        }
        public static bool CheckBookExists(this Manager manager, int bookKey)
        {
            if (manager.BookList.FindByKey(bookKey) != null)
            {
                return true;
            }
            return false;
        }
        public static bool CheckBookAvailable(this Manager manager, int bookKey)
        {
            Book book = manager.BookList.FindByKey(bookKey);
            if (book != null)
            {
                if (book)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

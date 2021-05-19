using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SearchSpace
{
    class SingleBookOnHand : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            var query = from room in manager.RoomList
                        where room.OccupiedBy.Count() > 0
                        from key in room.OccupiedBy
                        join reader in manager.ReaderList
                        on key equals reader.ReaderKey
                        into res
                        from r in res
                        from bookKey in r.OnHandBooks
                        join book in manager.BookList
                        on bookKey equals book.BookKey
                        
                        select new
                        {
                            room = room.RoomKey,
                            reader = r.LastName,
                            readerKey = key,
                            bookKey = bookKey,
                            bookAuthor = book.BookAuthor,
                            bookName = book.BookName,
                            bookQuantity = book.Quantity
                        };
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    if (item.bookQuantity == 1)
                    {
                        WriteLine(item);
                    }
                }
            }
            else
            {
                WriteLine("Nothing to show");
            }
        }
    }
}

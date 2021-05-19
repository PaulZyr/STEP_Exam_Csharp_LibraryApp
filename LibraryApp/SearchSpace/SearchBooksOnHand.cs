using LibraryApp.ManagerSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.SearchSpace
{
    class SearchBooksOnHand : SearchLibrary
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
                            _room = room.RoomKey,
                            _reader = r.LastName,
                            _readerKey = key,
                            _bookKey = bookKey,
                            _bookAuthor = book.BookAuthor,
                            _bookName = book.BookName
                        };
            if (query.Count() > 0)
            {
                foreach (var item in query)
                {
                    WriteLine(item);
                }
            }
            else
            {
                WriteLine("Nothing to show");
            }
            
        }
    }
}

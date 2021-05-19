using LibraryApp.RoomSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.BookSpace
{
    public class Book
    {
        public Book()
        {
            OnHandReaderKeys = new List<int>();
            BookAuthor = "";
            BookName = "";
        }
        public int BookKey { get; set; }
        public int RoomKey { get; set; }
        public string BookAuthor { get; set; }
        public string BookName { get; set; }
        public int IssueYear { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public List<int> OnHandReaderKeys { get; set; }

        public static bool operator true(Book book)
        {
            return (book.Quantity - book.OnHandReaderKeys.Count() > 0) ? true : false;
        }
        public static bool operator false(Book book)
        {
            return (book.Quantity - book.OnHandReaderKeys.Count() <= 0) ? true : false;
        }

        //public bool Available()
        //{
        //    if (Quantity - OnHandReaderKeys.Count() > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
        public override string ToString()
        {
            return $"Room: {RoomKey} / Book Key: {BookKey} / {BookAuthor} " +
                $"/ {BookName} / {IssueYear} / Rating: {Rating} / Available: {Quantity - OnHandReaderKeys.Count()}";
        }
        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)OnHandReaderKeys).GetEnumerator();
        }
    }
}
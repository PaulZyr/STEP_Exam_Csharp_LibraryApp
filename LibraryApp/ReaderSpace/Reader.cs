using LibraryApp.BookSpace;
using LibraryApp.RoomSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.ReaderSpace
{
    public class Reader
    {
        public Reader()
        {
            OnHandBooks = new List<int>();
            LastName = "";
            FirstName = "";
            SecondName = "";
            Phone = "";
        }
        public int ReaderKey { get; set; }
        public int RoomKey { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Phone { get; set; }

        public List<int> OnHandBooks { get; private set; }

        public void AddOnHandBook(int bookKey)
        {
            if (!OnHandBooks.Contains(bookKey))
            {
                OnHandBooks.Add(bookKey);
                Console.WriteLine("DONE!");
            }
            else
            {
                Console.WriteLine("Not Done: This book already ONHAND");
            }
        }
        public void RemoveOnHandBook(int bookKey)
        {
            if (OnHandBooks.Contains(bookKey))
            {
                OnHandBooks.Remove(bookKey);
                Console.WriteLine("DONE!");
            }
            else
            {
                Console.WriteLine("Not Done: This book NOT ONHAND");
            }
        }
        public override string ToString()
        {
            return $"Room: {RoomKey} / Reader Key: {ReaderKey} / {LastName} {FirstName} {SecondName} / +{Phone}";
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)OnHandBooks).GetEnumerator();
        }
    }
}
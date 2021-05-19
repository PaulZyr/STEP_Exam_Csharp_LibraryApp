using LibraryApp.BookSpace;
using static System.Console;
using LibraryApp.CollectionSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ReaderSpace;

using System;

namespace LibraryApp.ManagerSpace
{
    
    public class Manager : IDisposable
    {
        public event Action SaveToXML;
        public Manager(string path)
        {
            Path = path;
            BookList = new LibraryCollection<Book>();
            ReaderList = new LibraryCollection<Reader>();
            RoomList = new LibraryCollection<Room>();
            _needToSave = false;
            SaveToXML += this.SaveDatabase;
        }
        
        private string _dyrPath;
        public bool _needToSave;
        private bool disposedValue;

        public string Path
        {
            get 
            { 
                return _dyrPath; 
            }
            set 
            { 
                _dyrPath = value;
                BooksPath = Path + @"\books.xml";
                ReadersPath = Path + @"\readers.xml";
                RoomsPath = Path + @"\rooms.xml";
            }
        }
        public string BooksPath { get; private set; }
        public string ReadersPath { get; private set; }
        public string RoomsPath { get; private set; }

        public LibraryCollection<Book> BookList { get; set; }
        public LibraryCollection<Reader> ReaderList { get; set; }
        public LibraryCollection<Room> RoomList { get; set; }

        public void OnSaveToXML()
        {
            if (SaveToXML != null)
            {
                SaveToXML.Invoke();
                _needToSave = false;
            }
            else
            {
                WriteLine("System: error with saving Database");
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    BookList.Dispose();
                    ReaderList.Dispose();
                    RoomList.Dispose();
                }
                BookList = null;
                ReaderList = null;
                RoomList = null;
                disposedValue = true;
            }
        }
        ~Manager()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

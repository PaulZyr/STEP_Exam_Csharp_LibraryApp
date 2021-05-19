using LibraryApp.BookSpace;
using LibraryApp.PrintSpace;
using LibraryApp.CollectionSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ReaderSpace;
using LibraryApp.InteractorSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.SortSpace;

namespace LibraryApp.ManagerSpace
{
    class ManageReader : ManageRoom
    {
        public Book Book { get; set; }
        public ManageReader(Manager manager) : base(manager)
        {

        }
        public ManageReader(Manager manager, Room room, Reader reader) : base(manager)
        {
            Reader = reader;
            Room = room;
        }

        public override void Manage()
        {
            
            if (Reader == null)
            {
                ChooseReaderMenu();
            }
            if (Reader == null)
            {
                return;
            }
            while (true)
            {
                Clear();
                ReaderInfo();
                BookInfo();
                Menu();
                int q = InteractorConsole.GetInt("Input: ");
                switch (q)
                {
                    case 1:
                        ChooseBook();
                        break;
                    case 2:
                        GiveOutBook();
                        Manager._needToSave = true;
                        break;
                    case 3:
                        ReturnBook();
                        Manager._needToSave = true;
                        break;
                    case 4:
                        AllBooksInRoom();
                        break;
                    case 5:
                        return;
                    default:
                        WriteLine("Wrong Input");
                        PressKeyToContinue();
                        break;
                }
                if (Manager._needToSave)
                {
                    Manager.OnSaveToXML();
                }
            }
        }

        public override void Menu()
        {
            Write("----- Reader Menu -----\n" +
                "1 - Choose a Book\n" +
                "2 - Give out the Book\n" +
                "3 - Return a Book\n" +
                "4 - All Books in Room\n" +
                "5 - Return to Previous Menu\n");
        }

        public void BookInfo()
        {
            WriteLine("Book to Give Out:");
            if (Book != null)
            {
                WriteLine(Book);
                if (Book)
                {
                    if (Reader != null && Reader.RoomKey == Book.RoomKey)
                    {
                        WriteLine("*** This Book available ****");
                    }
                    else
                    {
                        WriteLine("*** This Book NOT for this ROOM ****");
                    }
                }
                else
                {
                    WriteLine("*** This Book NOT available now ****");
                }
            }
            else
            {
                WriteLine("none");
            }
        }
        private void ChooseBook()
        {
            if (Room != null && Reader != null)
            {
                Book = Manager.BookList.FindByKey
                            (InteractorConsole.GetInt("Input Book Key: "));
                if (Book == null)
                {
                    WriteLine("No Book with this Key");
                    PressKeyToContinue();
                }
                else if (Room.RoomKey != Book.RoomKey)
                {
                    WriteLine("This Book CAN'T be Given in this Room");
                    PressKeyToContinue();
                }
            }
            else
            {
                AskToChoose(true);
            }
        }
        private void GiveOutBook()
        {
            if (Room != null && Reader != null && Book != null
                && Reader.RoomKey == Book.RoomKey)
            {
                if (Book)
                {
                    Reader.AddOnHandBook(Book.BookKey);
                    Book.OnHandReaderKeys.Add(Reader.ReaderKey);
                    Book.Rating++;
                    Book = null;
                }
                else
                {
                    WriteLine("The Book is Unavailable");
                }
            }
            else
            {
                AskToChoose(true);
            }
        }
        private void ReturnBook()
        {
            if (Room != null && Reader != null)
            {
                int key = InteractorConsole.GetInt("Input Book Key to return: ");
                if (key > 0 && Reader.OnHandBooks.Contains(key))
                {
                    Reader.OnHandBooks.Remove(key);
                    Book book = Manager.BookList.FindByKey(key);
                    if (book != null && book.OnHandReaderKeys.Contains(Reader.ReaderKey))
                    {
                        book.OnHandReaderKeys.Remove(Reader.ReaderKey);
                    }
                    Book = null;
                }
            }
        }
        private void ChooseReaderMenu()
        {
            while(true)
            {
                Reader = Manager.ReaderList.FindByKey
                            (InteractorConsole.GetInt("You need to choose Reader first\nInput Reader Key: "));
                if (Reader == null)
                {
                    WriteLine("No Reader with this Key\n" +
                        "Try again (Y) or Return (N)");
                    if(!InteractorConsole.GetString("Input (Y/N): ").Contains('Y'))
                    {
                        return;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        private void AllBooksInRoom()
        {
            if (Room != null && Reader != null)
            {
                new PrintBooksForOneRoom().Print(Manager, Room.RoomKey);
                PressKeyToContinue();
            }
            else
            {
                AskToChoose(true);
            }  
        }
    }
}

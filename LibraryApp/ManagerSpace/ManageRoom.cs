using LibraryApp.BookSpace;
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
using LibraryApp.SearchSpace;
using LibraryApp.SortSpace;
using LibraryApp.PrintSpace;

namespace LibraryApp.ManagerSpace
{
    class ManageRoom
    {
        public ManageRoom(Manager manager)
        {
            Manager = manager;
        }
        public Manager Manager { get; set; }
        public Room Room { get; set; }
        public Reader Reader { get; set; }

        public virtual void Manage()
        {
            while(true)
            {
                Clear();
                RoomInfo();
                ReaderInfo();
                Menu();
                switch (InteractorConsole.GetInt("Input: "))
                {
                    case 1:
                        ChooseRoom();
                        break;
                    case 2:
                        ChooseReader();
                        break;
                    case 3:
                        SearchReadersForRoom();
                        break;
                    case 4:
                        SeatReader();
                        Manager._needToSave = true;
                        break;
                    case 5:
                        UnseatReader();
                        Manager._needToSave = true;
                        break;
                    case 6:
                        ListOfSeatedReaders();
                        break;
                    case 7:
                        ToReaderMenu();
                        break;
                    case 8:
                        return;
                    default:
                        WriteLine("Wrong input");
                        break;
                }
                if (Manager._needToSave)
                {
                    Manager.OnSaveToXML();
                }
            }
        }
        public void RoomInfo()
        {
            WriteLine("Room:");
            if (Room != null)
            {
                WriteLine(Room);
            }

        }
        public void ReaderInfo()
        {
            WriteLine("Reader:");
            if (Reader != null)
            {

                WriteLine(Reader);
                if (Room.OccupiedBy.Contains(Reader.ReaderKey))
                {
                    WriteLine("*** The Reader is Seated ****");
                }
                else if (Manager.CheckRoomFreePlace(Reader.RoomKey))
                {
                    WriteLine("*** The ROOM has a free place ****");
                }
                else
                {
                    WriteLine("*** NO FREE PLACE in the ROOM ****");
                }
                WriteLine("Books On Hand:");
                if (Reader.OnHandBooks.Count() > 0)
                {
                    foreach (var item in Reader.OnHandBooks)
                    {
                        Book tmp = Manager.BookList.FindByKey(item);
                        if (tmp != null)
                        {
                            WriteLine(tmp);
                        }
                    }
                }
                else
                {
                    WriteLine("none");
                }
            }
            else
            {
                WriteLine("none");
            }
        }
        
        public virtual void Menu()
        {
            Write("----- Manage Room Menu -----\n" +
                "1 - Choose a Room to manage\n" +
                "2 - Choose a Reader to manage\n" +
                "3 - List of All Readers for this Room\n" +
                "4 - Seat the Reader\n" +
                "5 - Unseat the Reader\n" +
                "6 - List of Seated Readers in the Room\n" +
                "7 - Manage Reader's Books\n" +
                "8 - Return to the Main Menu\n");
        }

        private void ChooseRoom()
        {
            Room = Manager.RoomList.FindByKey
                            (InteractorConsole.GetInt("Input Room Key: "));
            if (Room == null)
            {
                WriteLine("No Room with this Key");
                PressKeyToContinue();
            }
        }

        private void ChooseReader()
        {
            if (Room != null)
            {
                Reader = Manager.ReaderList.FindByKey
                            (InteractorConsole.GetInt("Input Reader Key: "));
                if (Reader == null) // no reader
                {
                    WriteLine("No Reader with this Key");
                    PressKeyToContinue();
                }
                else if (Reader.RoomKey != Room.RoomKey) // wrong room
                {
                    WriteLine("This Reader has NO PERMISION for this ROOM");
                    PressKeyToContinue();
                    Reader = null;
                }
            }
            else
            {
                AskToChoose(false);
            }
        }

        private void SearchReadersForRoom()
        {
            if (Room != null)
            {
                new PrintReadersForOneRoom().Print(Manager, Room.RoomKey);
                PressKeyToContinue();
            }
            else
            {
                AskToChoose(false);
            }
        }

        private void ToReaderMenu()
        {
            if (Room != null && Reader != null)
            {
                new ManageReader(Manager, Room, Reader).Manage();
            }
            else
            {
                AskToChoose(true);
            }
        }

        private void SeatReader()
        {
            if (Room != null && Reader != null)
            {
                if (!Room.OccupiedBy.Contains(Reader.ReaderKey))
                {
                    Room.OccupiedBy.Add(Reader.ReaderKey);
                }
                else
                {
                    WriteLine("This Reader already SEATED");
                    PressKeyToContinue();
                }
            }
            else
            {
                AskToChoose(true);
            }
        }
        private void UnseatReader()
        {
            if (Room != null && Reader != null)
            {
                if (Room.OccupiedBy.Contains(Reader.ReaderKey))
                {
                    if (Manager.CheckBooksReturned(Reader.ReaderKey))
                    {
                        Room.OccupiedBy.Remove(Reader.ReaderKey);
                    }
                    else
                    {
                        WriteLine("This Reader still has BOOKS On Hand\n" +
                            "Return the books first!\n");
                        PressKeyToContinue();
                    }
                }
                else
                {
                    WriteLine("This Reader are NOT SEATED in this Room");
                    PressKeyToContinue();
                }
            }
            else
            {
                AskToChoose(true);
            }
        }
        public void ListOfSeatedReaders()
        {
            if (Room != null)
            {
                Clear();
                RoomInfo();
                if (Room.OccupiedBy.Count() > 0)
                {
                    foreach (var item in Room.OccupiedBy)
                    {
                        Reader tmp = Manager.ReaderList.FindByKey(item);
                        if (tmp != null)
                        {
                            WriteLine(tmp);
                        }
                    }
                }
                else
                {
                    WriteLine("NO Readers in the Room");
                }
                PressKeyToContinue();
            }
            else
            {
                AskToChoose(false);
            }
        }

        public void AskToChoose(bool b)
        {
            Write("Choose a Room FIRST");
            if (b)
            {
                Write(" and then a Reader");
            }
            PressKeyToContinue();
        }
        public void PressKeyToContinue()
        {
            WriteLine("\nPress any key to continue...");
            ReadKey();
        }
    }
}

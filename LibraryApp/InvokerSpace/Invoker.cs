using LibraryApp.BookSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.SearchSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ReaderSpace;
using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;
using LibraryApp.SortSpace;
using LibraryApp.PrintSpace;

namespace LibraryApp.InvokerSpace
{
    class Invoker
    {

        Manager _manager;

        public Invoker(Manager manager)
        {
            _manager = manager;
        }

        public void Start()
        {

            while (true)
            {
                switch(Interactor.WaitForCommand())
                {
                    case 1:
                        new ManageRoom(_manager).Manage();
                        _manager._needToSave = true;
                        break;
                    case 2:
                        new ManageReader(_manager).Manage();
                        _manager._needToSave = true;
                        break;
                    case 3:
                        new SearchRoomsByFreeSeats().Search(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 4:
                        new SearchBooksOnHand().Search(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 5:
                        new SearchBooksByOneAuthor().Search(_manager); // +
                        break;
                    case 6:
                        new SearchRoomsByOccupation().Search(_manager); // +
                        break;
                    case 7:
                        new SearchBooksByRating().Search(_manager); // +
                        break;
                    case 8:
                        new SearchReaderByKey().Search(_manager); // +
                        break;
                    case 9:
                        new SearchReaderBylastName().Search(_manager); // +
                        break;

                    case 11:
                        new InvokerAddNewReader().Add(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 13:
                        new PrintAllRoomsFullInfo().Print(_manager); // +
                        break;
                    case 14:
                        new SortReadersByRoom().Sort(_manager); // +
                        break;
                    case 15:
                        new SortReadersByKey().Sort(_manager); // +
                        break;
                    case 16:
                        new SortReadersByLastName().Sort(_manager); // +
                        break;
                    case 17:
                        new SortBooksByRoom().Sort(_manager); // +
                        break;
                    case 18:
                        new SortBooksByAuthor().Sort(_manager); // -
                        break;
                    case 19:
                        new SingleBookOnHand().Search(_manager); // +
                        break;
                    case 20:
                        new InvokerChangeReader().Change(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 21:
                        new InvokerAddNewBook().Add(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 22:
                        new InvokerChangeBook().Change(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 23:
                        new InvokerAddNewRoom().Add(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 24:
                        new InvokerChangeRoom().Change(_manager); // +
                        _manager._needToSave = true;
                        break;
                    case 0:
                        throw new Exception("exit");
                }

                if (_manager._needToSave)
                {
                    _manager.OnSaveToXML();
                }

                WriteLine("Press any key to continue...");
                ReadKey();
            }
        }
    }
}

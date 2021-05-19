using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.BookSpace
{
    class BookChanger
    {
        public Book Change(Book book)
        {
            while(true)
            {
                Clear();
                WriteLine(book);
                WriteLine("---  Change  ---\n" +
                    "1 - Book Key\n" +
                    "2 - Room Key\n" +
                    "3 - Author\n" +
                    "4 - Book Name\n" +
                    "5 - Issue Year\n" +
                    "6 - Quantity\n" +
                    "7 - Rating\n" +
                    "0 - Finish changing\n");
                string str = ReadLine();
                switch(str[0])
                {
                    case '1':
                        book.BookKey = InteractorConsole.GetInt("Input Book Key: ");
                        break;
                    case '2':
                        book.RoomKey = InteractorConsole.GetInt("Input Room Key: ");
                        break;
                    case '3':
                        Write("Input Author name: ");
                        book.BookAuthor = InteractorConsole.GetString("Input Author Name: ");
                        break;
                    case '4':
                        Write("Input Book name: ");
                        book.BookName = InteractorConsole.GetString("Input Book Name: ");
                        break;
                    case '5':
                        book.IssueYear = InteractorConsole.GetInt("Input Issue Year: ");
                        break;
                    case '6':
                        book.Quantity = InteractorConsole.GetInt("Input Quantity: ");
                        break;
                    case '7':
                        book.Rating = InteractorConsole.GetInt("Input new Rating: ");
                        break;
                    case '0':
                        return book;
                    default:
                        WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
}

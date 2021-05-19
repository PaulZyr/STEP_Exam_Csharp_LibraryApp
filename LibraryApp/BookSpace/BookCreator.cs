using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.BookSpace
{
    class BookCreator
    { 
        public Book Create()
        {
            Book book = new Book();

            Clear();
            book.BookKey = InteractorConsole.GetInt("Input Book Key (number): ");
            book.RoomKey = InteractorConsole.GetInt("Input Room Key for this book (number): ");

            Write("Input Author name: ");
            book.BookAuthor = InteractorConsole.GetString("Input Author Name: ");

            Write("Input Book name: ");
            book.BookName = InteractorConsole.GetString("Input Book Name: ");

            book.IssueYear = InteractorConsole.GetInt("Input Issue Year: ");
            book.Quantity = InteractorConsole.GetInt("Input Quantity: ");


            WriteLine("New Book: \n" + book);
            Write("Accept (y) or Change (n): ");
            string str = ReadLine();
            str = str.ToUpper();
            if (str == "Y" || str == "YES")
            {
                return book;
            }
            else
            {
                book = new BookChanger().Change(book);
            }
            return book;
        }
    }
}

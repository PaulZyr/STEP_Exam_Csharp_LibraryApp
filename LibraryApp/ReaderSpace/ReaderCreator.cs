using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.ReaderSpace
{
    class ReaderCreator
    {
        public Reader Create()
        {
            Reader reader = new Reader();

            Clear();
            reader.ReaderKey = InteractorConsole.GetInt("Input Reader Key (number): ");
            reader.RoomKey = InteractorConsole.GetInt("Input Room Key for this book (number): ");

            Write(": ");
            reader.LastName = InteractorConsole.GetString("Input Reader Last Name: ");
            Write("Input Reader First Name: ");
            reader.FirstName = InteractorConsole.GetString("Input Reader First Name: ");
            Write("Input Reader Second Name: ");
            reader.SecondName = InteractorConsole.GetString("Input Reader Second Name: ");

            reader.Phone = InteractorConsole.GetPhone();

            WriteLine("New Reader: \n" + reader);
            Write("Accept (y) or Change (n): ");
            string str = ReadLine();
            str = str.ToUpper();
            if (str == "Y" || str == "YES")
            {
                return reader;
            }
            else
            {
                reader = new ReaderChanger().Change(reader);
            }
            return reader;
        }
    }
}

using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;

namespace LibraryApp.ReaderSpace
{
    class ReaderChanger
    {
        public Reader Change(Reader reader)
        {
            while (true)
            {
                Clear();
                WriteLine(reader);
                WriteLine("---  Change  ---\n" +
                    "1 - Reader Key\n" +
                    "2 - Room Key\n" +
                    "3 - Last Name\n" +
                    "4 - First Name\n" +
                    "5 - Second Name\n" +
                    "6 - Phone\n" +
                    "0 - Finish changing\n");
                string str = ReadLine();
                switch (str[0])
                {
                    case '1':
                        reader.ReaderKey = InteractorConsole.GetInt("Input Reader Key: ");
                        break;
                    case '2':
                        reader.RoomKey = InteractorConsole.GetInt("Input Room Key: ");
                        break;
                    case '3':
                        reader.LastName = InteractorConsole.GetString("Input Last Name: ");
                        break;
                    case '4':
                        reader.FirstName = InteractorConsole.GetString("Input First Name: ");
                        break;
                    case '5':
                        reader.SecondName = InteractorConsole.GetString("Input Second Name: ");
                        break;
                    case '6':
                        Write("Input Phone Number: ");
                        reader.Phone = InteractorConsole.GetPhone();
                        break;
                    case '0':
                        return reader;
                    default:
                        WriteLine("Wrong choice!");
                        break;
                }
            }
        }
    }
}

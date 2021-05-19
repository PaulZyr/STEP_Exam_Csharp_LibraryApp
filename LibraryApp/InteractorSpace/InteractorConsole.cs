using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LibraryApp.InteractorSpace
{
    public static class InteractorConsole
    {
        public static int GetInt(string msg)
        {
            string str;
            int n;
            while (true)
            {
                Write(msg);
                str = ReadLine();
                if (Int32.TryParse(str, out n))
                {
                    if (n >= 0)
                    {
                        return n;
                    }
                    else
                    {
                        WriteLine("Number can't be negative");
                    }
                }
                else
                {
                    WriteLine("Wrong input");
                }

                Write("Input right number(y) or return(n)?: ");
                str = ReadLine();
                str = str.ToUpper();
                if (str != "Y" || str != "YES")
                {
                    return -1;
                }
            }
        }

        public static string GetPhone()
        {
            WriteLine("Input Phone Number in '380331234567' format:");
            string phone = ReadLine();
            if (Regex.IsMatch(phone, @"[3][8][0][1-9][0-9]{8}"))
            {
                return phone;
            }
            else
            {
                WriteLine("Wrong format");
                return "none";
            }
        }
        public static string GetString(string msg)
        {
            Write(msg);
            string str = ReadLine().ToUpper();

            return str;
        }

    }
}

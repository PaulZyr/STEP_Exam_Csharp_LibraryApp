using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InteractorSpace
{
    public static class Interactor
    {
        public static int WaitForCommand()
        {
            string msg = "";
            int q;
            while (true)
            {
                q = -1;
                MainMenu(msg);
                q = InteractorConsole.GetInt("Input: ");
                if (q >=0 && q <= 12)
                {
                    if (q==10)
                    {
                        q = SearchMenu();
                    }
                    else if (q==12)
                    {
                        q = AddChangeMenu();
                    }

                    if (q != -1)
                    {
                        return q;
                    }
                }
                else
                {
                    msg = "Wrong Input!";
                }
            }
        }
        static void MainMenu(string msg)
        {
            
            Clear();
            Write("--------- Main Menu: ---------\n" +
                "   1 - Manage Room\n" +
                "   2 - Manage Reader\n" +
				"-------- SEARCH MENU ---------\n" +
                "   3 - Search Free Seats\n" +
                "   4 - Books on Hand\n" +
                "   5 - One Author's books\n" +
                "   6 - Rooms by Occupation\n" +
                "   7 - Highest Rating's Books\n" +
                "   8 - Search Reader by Key\n" +            
                "   9 - Search Reader by Last Name\n" +
                "   10 - MORE Searches\n" +
				"-------- ADD / CHANGE --------\n" +
                "   11 - Add new Reader\n" +
                "   12 - Change Menu\n" +
                "------------------------------\n" +
                "   0 - Save & Exit\n" +
                "------------------------------\n");
            if (msg != "")
            {
                WriteLine(msg);
            }
        }
        static int SearchMenu()
        {
            Clear();
            Write("-------- SEARCH MENU ---------\n" +
                "   13 - All Rooms FULL Info\n" +
                "   14 - All Readers Sorted by Room\n" +
                "   15 - All Readers Sorted by Key\n" +
                "   16 - All Readers Sorted by LastName\n" +
                "   17 - All Books Sorted by Room\n" +
                "   18 - All Books Sorted by Author\n" +
				"   19 - Single Book Items ON Hand\n" +
                
                "-------------------------------\n" +
                "   0 - Back\n" +
                "-------------------------------\n");
            int q = InteractorConsole.GetInt("Input: ");
            if (q >= 12 && q <= 21)
            {
                return q;
            }
            else if (q != 0)
            {
                WriteLine("Wrong input");
            }
            return -1;
        }
        static int AddChangeMenu()
        {
            
            Clear();
            Write("--------- BE CAREFULL ---------\n" +
                "   20 - Change Reader\n" +
                "   21 - Add new Book\n" +
                "   22 - Change Book\n" +
                "   23 - Add new Room\n" +
                "   24 - Change Room\n" +
                "------------------------------\n" +
                "   0 - Back\n" +
                "------------------------------\n");
            string str = ReadLine();
            int q = InteractorConsole.GetInt("Input: ");
            if (q >= 30 && q <= 34)
            {
                return q;
            }
            else if (q!=0)
            {
                WriteLine("Wrong input");
            }  
            return -1;
        }
    }
}

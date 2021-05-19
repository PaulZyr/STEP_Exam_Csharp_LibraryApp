using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;
using LibraryApp.ReaderSpace;
using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;

namespace LibraryApp.InvokerSpace
{
    class InvokerChangeReader
    {
        public void Change(Manager manager)
        {
            Clear();
            WriteLine("--- Change Reader ---\n" +
                "1 - Input Reader Key\n" +
                "2 - Show All Readers\n" +
                "0 - Return\n");
            string str = ReadLine();
            if (str == "2")
            {
                WriteLine(manager.ReaderList);
            }
            else if (str == "0")
            {
                return;
            }
            int key = InteractorConsole.GetInt("Input Reader Key");
            Reader reader = manager.ReaderList.FindByKey(key);
            if (reader != null)
            {
                reader = new ReaderChanger().Change(reader);
            }
        }
    }
}

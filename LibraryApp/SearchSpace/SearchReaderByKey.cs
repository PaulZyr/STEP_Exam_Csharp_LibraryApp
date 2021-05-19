using LibraryApp.ReaderSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.InteractorSpace;
using LibraryApp.ManagerSpace;
using LibraryApp.CollectionSpace;

namespace LibraryApp.SearchSpace
{
    class SearchReaderByKey : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            int key = InteractorConsole.GetInt("Input key: ");

            if (key > 0)
            {
                Reader reader = manager.ReaderList.FindByKey(key);
                if (reader != null)
                {
                    WriteLine(reader);
                }
                else
                {
                    WriteLine("No reader with this Key");
                }
            }
        }
    }
}

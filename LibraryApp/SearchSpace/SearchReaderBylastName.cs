using LibraryApp.InteractorSpace;
using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryApp.ManagerSpace;

namespace LibraryApp.SearchSpace
{
    class SearchReaderBylastName : SearchLibrary
    {
        public override void Search(Manager manager)
        {
            string name = InteractorConsole.GetString("Input Reader Last Name (at least 4 letters): ");
            if (name != "" || name.Length > 3)
            {
                var query = from reader in manager.ReaderList
                            where reader.LastName.Contains(name)
                            select reader;

                if (query.Count()!=0)
                {
                    foreach (var q in query)
                    {
                        if (q != null)
                        {
                            WriteLine(q);
                        }
                    }
                }
                else
                {
                    WriteLine("Empty");
                }
            }
            else
            {
                WriteLine("Too short input");
            }
        }
    }
}

using LibraryApp.ManagerSpace;
using LibraryApp.ReaderSpace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.InvokerSpace
{
    class InvokerAddNewReader
    {
        public void Add(Manager manager)
        {
            Reader reader = new ReaderCreator().Create();
            while (true)
            {
                if (reader != null && manager.CheckNewReaderValid(reader))
                {
                    manager.ReaderList.Add(reader);
                    break;
                }
                else
                {
                    Console.WriteLine("You need to change a Reader Key");
                    reader = new ReaderChanger().Change(reader);
                }
            }
        }
    }
}

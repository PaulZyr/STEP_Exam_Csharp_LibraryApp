using LibraryApp.BookSpace;
using LibraryApp.InvokerSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ManagerSpace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LibraryApp.ReaderSpace;
using System.Xml;

namespace LibraryApp
{
    class Program
    {
        // Зырянов Павел, STEP_PE911
        // курсовая C# 'Библиотека'
        static void Main(string[] args)
        {
            Hello();

            try
            {
                Manager manager = new ManagerCreator().Create();
                if (manager != null)
                {
                    Invoker invoker = new Invoker(manager);

                    invoker.Start();
                }
                manager.Dispose();
            }
            catch(Exception ex)
            {
                switch(ex.Message)
                {
                    case "exit":
                        break;
                    default:
                        Console.WriteLine(ex.Message);
                        break;
                }
            }

            ByeBye();
            Console.ReadKey();
        }

        static void Hello()
        {
            Console.WriteLine("Hello!");
            System.Threading.Thread.Sleep(1000);
        }

        static void ByeBye()
        {
            Console.WriteLine("Bye-Bye");
        }
    }
}

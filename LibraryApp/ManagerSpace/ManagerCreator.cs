using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibraryApp.CollectionSpace;
using LibraryApp.InteractorSpace;
using LibraryApp.XMLFiles;
using LibraryApp.BookSpace;
using LibraryApp.RoomSpace;
using LibraryApp.ReaderSpace;

namespace LibraryApp.ManagerSpace
{
    class ManagerCreator
    {
        public ManagerCreator()
        {
            _pathDefault = "database";
            _path = _pathDefault;
        }

        private Manager _manager;

        private string _path;
        private string _pathDefault;
        private string _pathBooks;
        private string _pathReaders;
        private string _pathRooms;

        public Manager Create()
        {
            bool b = true;
            string str = "";
            while (b)
            {
                LoadMenu();

                int q = InteractorConsole.GetInt("Input: ");

                switch (q)
                {
                    case 1:
                        if (Directory.Exists(_path))
                        {
                            b = false;
                        }
                        else
                        {
                            WriteLine("No Directory at default Path");
                        }
                        break;
                    case 2:
                        if (InputPath())
                        {
                            b = false;
                        }
                        else
                        {
                            _path = _pathDefault;
                        }
                        break;
                }

                if (!b)
                {
                    CreateFilePath();

                    if (!CheckFiles())
                    {
                        Write($"No Database Files in: {_path}\n" +
                            $"Create new Database Files in {_path} ?\n" +
                            $"Y/N: ");
                        str = ReadLine().ToUpper();

                        if (str.Contains('Y'))
                        {
                            CreateFiles();
                        }
                        else
                        {
                            b = true;
                        }
                    }
                }

                if (!b)
                {
                    CheckXMLFileValid checker = new CheckXMLFileValid();

                    if (!checker.Check(_pathRooms))
                    {
                        WriteLine("Room File is NOT Correct!");
                        b = true;
                    }
                    if (!checker.Check(_pathReaders))
                    {
                        WriteLine("Reader File is NOT Correct!");
                        b = true;
                    }
                    if (!checker.Check(_pathBooks))
                    {
                        WriteLine("Book File is NOT Correct!");
                        b = true;
                    }
                }
            }

            _manager = new Manager(_path);

            LoadDatabase();

            return _manager;

        }

        void LoadMenu()
        {
            Clear();
            Write("1 - Load Database\n" +
                "2 - Input Directory Path and Load\n" +
                "0 - Exit LibraryApp\n");
        }
        bool InputPath()
        {
            string str = "";
            while(true)
            {
                Clear();
                WriteLine("Input directory path: ");
                string path = ReadLine();

                if (!Directory.Exists(path))
                {
                    Write("No such Directory\n" +
                        "Create this Directory?\n" +
                        "Y/N: ");
                    str = ReadLine().ToUpper();
                    if (str.Contains('N'))
                    {
                        return false;
                    }
                    CreateDirectory(path);
                }
                _path = path;
                return true;
            }
        }
        void LoadDatabase()
        {
            
            try
            {
                _manager.BookList.Load(_pathBooks);
                _manager.ReaderList.Load(_pathReaders);
                _manager.RoomList.Load(_pathRooms);
            }
            catch(Exception ex)
            {
                throw new Exception("Can't load Database: " + ex.Message);
            }
        }
        bool CheckFiles()
        {
            if (File.Exists(_pathBooks) 
                && File.Exists(_pathRooms)
                && File.Exists(_pathReaders))
            {
                return true;
            }

            return false;
        }
        bool CreateDirectory(string dyrPath)
        {
            try
            {
                Directory.CreateDirectory(dyrPath);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        bool CreateFiles()
        {
            try
            {
                new LibraryCollection<Room>().Save(_pathRooms);
                new LibraryCollection<Reader>().Save(_pathReaders);
                new LibraryCollection<Book>().Save(_pathBooks);
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        
        void CreateFilePath()
        {
            _pathBooks = _path + @"\books.xml";
            _pathRooms = _path + @"\rooms.xml";
            _pathReaders = _path + @"\readers.xml";
        }
    }
}

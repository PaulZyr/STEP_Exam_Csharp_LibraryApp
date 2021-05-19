using System;
using static System.Console;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LibraryApp.CollectionSpace
{
    public class LibraryCollection<T> : IEnumerable<T>, IDisposable
    {
        public LibraryCollection()
        {
            _itemList = new List<T>();
            disposedValue = false;
        }
        private List<T> _itemList;

        private bool disposedValue;

        public void Add(T item)
        {
            if (item != null)
            {
                if (!_itemList.Contains(item))
                {
                    _itemList.Add(item);
                }
                else WriteLine($"This {typeof(T).Name} already exists in the List");
            }
            else throw new Exception("System: item == null.");
        }
        public void Remove(T item)
        {
            if (item != null)
            {
                if (_itemList.Contains(item))
                {
                    _itemList.Remove(item);
                }
                else WriteLine($"The {typeof(T).Name} is NOT in the Collection.");
            }
            else throw new Exception("System: book == null.");
        }
        public void Clear()
        {
            _itemList = new List<T>();
        }
        
        public void Save(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            try
            {
                using (Stream fStream = File.Create(path))
                {
                    xmlSerializer.Serialize(fStream, _itemList);
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Load(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            try
            {
                using (Stream fStream = File.OpenRead(path))
                {
                    _itemList = (List<T>)xmlSerializer.Deserialize(fStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public T this[int index]
        {
            get
            {
                return _itemList[index];
            }
            set
            {
                if (_itemList != null)
                {
                    if (value != null && value is T)
                    {
                        if (index >= 0 && index <= _itemList.Count())
                        {
                            _itemList[index] = value;
                        }
                        else
                        {
                            WriteLine($"Wrong index. Must be 0 through {_itemList.Count()}");
                        }
                    }
                    else
                    {
                        throw new Exception($"Value is not a {typeof(T).Name}");
                    }
                }
                else
                {
                    WriteLine($"List of {typeof(T).Name}s is EMPTY");
                }

            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)_itemList).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_itemList).GetEnumerator();
        }

        public override string ToString()
        {
            if (_itemList.Count() > 0)
            {
                string str = $"----- List of {typeof(T).Name}s -----\n";
                foreach (var item in _itemList)
                {
                    str += item.ToString() + "\n";
                }
                return str;
            }
            else
            {
                return $"----- List of {typeof(T).Name}s is EMPTY -----";
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_itemList != null)
                    {
                        for (var i = 0; i < _itemList.Count(); i++)
                        {
                            _itemList[i] = default(T);
                        }
                    }
                }
                _itemList = null;
                disposedValue = true;
            }
        }

        ~LibraryCollection()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

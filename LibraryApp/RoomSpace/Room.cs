using LibraryApp.ReaderSpace;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.RoomSpace
{
    public class Room
    {
        public Room()
        {
            OccupiedBy = new List<int>();
            RoomName = "";
        }
        
        public int RoomKey { get; set; }
  
        public string RoomName { get; set; }
        public int RoomCapacity { get; set; }

        public List<int> OccupiedBy { get; set; }

        public int FreePlace()
        {
            return RoomCapacity - OccupiedBy.Count();
        }
        public void AddReader(int readerKey)
        {
            if (readerKey > 0)
            {
                OccupiedBy.Add(readerKey);
            }
            else throw new Exception("invalid Reader Code");
        }
        public void RemoveReader(int readerKey)
        {
            if (OccupiedBy.Contains(readerKey))
            {
                OccupiedBy.Remove(readerKey);
            }
            else Console.Write("No such Reader in the Room Reader List.");
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)OccupiedBy).GetEnumerator();
        }

        public override string ToString()
        {
            return $"Room Key: {RoomKey}, Name: '{RoomName}', Capacity: {RoomCapacity}, Free: {FreePlace()}";
        }
    }
}

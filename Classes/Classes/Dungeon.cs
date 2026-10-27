using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace Classes
{
    public class Dungeon
    {
        public Room[] Room = new Room[]
                {
                new Room (new Unit("name",10), new Weapon("Name",2,10,10f)),
                new Room (new Unit("name",20), new Weapon("Name",3,9,10f)),
                new Room (new Unit("name",30), new Weapon("Name",2,10,10f))
                };
        public Dungeon()
        {
        }

        public void ShowRooms()
        {
            for (int i = 0; i < Room.Length; i++)
            {
                var rooms = Room[i];
                Console.WriteLine("Unit of room "+ rooms.Unit);
                Console.WriteLine("Weapon of room "+ rooms.Weapon);
                Console.WriteLine("—");
            }
        }

    }
}

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
                Console.WriteLine("Unit of room {0}, {1} ",rooms.Unit.Name, rooms.Unit.Damage);
                Console.WriteLine("Weapon of room {0}, {1}, {2}", rooms.Weapon.Name, rooms.Weapon.Damage, rooms.Weapon.Durability);
                Console.WriteLine("—");
            }
        }

    }
}

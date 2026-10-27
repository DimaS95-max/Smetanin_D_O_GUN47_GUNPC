using System.Xml.Linq;

namespace Classes
{
   



    public struct Interval
    {
        public int Min { get; }
        public int Max { get; }
        public int Get { get; }

        private static readonly Random rand = new Random();

        public int GetRandom(int min, int max)
        {return rand.Next(min, max);}

        public Interval (int minValue, int maxValue)
        {
            if (minValue > maxValue)
            {
                (minValue, maxValue) = (maxValue, minValue);
                Console.WriteLine("Данные введены некорректно");
            }

            if (minValue<0)
            {
                minValue = 0;
                Console.WriteLine("Данные введены некорректно");
            }
            if (maxValue < 0)
            {
                maxValue = 0;
                Console.WriteLine("Данные введены некорректно");
            }

            if (maxValue== minValue)
            {
                maxValue = minValue+10;
                Console.WriteLine("Данные введены некорректно");
            }
            Min=minValue; 
            Max=maxValue;
            Get = GetRandom(minValue, maxValue);

        }
    }





    public struct Room
    {
        public Unit Unit;
        public Weapon Weapon;

        public Room(Unit unit, Weapon weapon)
        {
            Unit = unit;
            Weapon = weapon;
        }

    }



    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою");
            Console.WriteLine("Введите имя бойца:");
            string? name = Console.ReadLine();
            if (name == null)
            {
                name = "Unknown Unit";
                Console.WriteLine("Введено некорректное имя");
                return;
            }

            Console.WriteLine("Введите название оружия:");
            string? Name = Console.ReadLine();
            if (Name == null)
            {
                Name = "weapon";
                Console.WriteLine("Введено некорректное название оружия");
                return;
            }

            Console.WriteLine("Введите начальное здоровье бойца (10-100):");

            if (!int.TryParse(s: Console.ReadLine(), out int health))
            {
                Console.WriteLine("Введено некорректное число");
                return;
            }
           
            var object1 = new Weapon(Name, 4, 10, 20f);
            var GetDamage = object1.GetDamage();

            var object2 = new Interval(object1.MinDamage, object1.MaxDamage);

            var object3 = new Unit(name, health);

            var object4 = new Unit(10);

            Console.WriteLine("Введите полученный дамаг:");
            if (!int.TryParse(s: Console.ReadLine(), out int value))
            {
                Console.WriteLine("Введено некорректное число");
                return;
            }
            var RealHealth = object3.GetRealHealth();
            var returnHealth = object3.SetDamage(value);
            Console.WriteLine("Реальное здоровье бойца до атаки= {0}, после атаки боец мертв= {1}, Наносимый урон= {2}", RealHealth, returnHealth, object2.Get);
            Console.WriteLine("Мин. урон оружия= {0}, Макс. урон оружия= {1}, Средний урон= {2}", object1.MinDamage, object1.MaxDamage, GetDamage);

            var object5 = new Dungeon();
            Console.WriteLine("Массив- {0}, {1}, {2}", object5.Room[0], object5.Room[1], object5.Room[2]);
            object5.ShowRooms();



        }
    }
}

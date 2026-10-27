using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Weapon
    {
        public string Name { get; }
        public int MinDamage { get; private set;}
        public int MaxDamage { get; private set;}
        public float Durability { get; set;}

        public Weapon(string name)
        {
            Name = name;
        }

        public Weapon(string name, int minDamage, int maxDamage, float durability) :this(name)
        {
            Name = name;
            SetDamageParams(minDamage, maxDamage, durability);
        }

        public void SetDamageParams(int minDamage, int maxDamage, float durability)
        {
            if (minDamage > maxDamage)
            {
                (minDamage, maxDamage) = (maxDamage, minDamage);
                Console.WriteLine("Недопустимые значения оружия {0}", Name);
            }

            if (minDamage < 1)
            {
                float f = minDamage;
                minDamage = (int)f;
                Console.WriteLine("Форсированная установка минимального значения");
            }

            if (maxDamage <= 1)
            {
                maxDamage = 10;
            }
            var object1= new Interval (minDamage, maxDamage);
            MinDamage = object1.Min; 
            MaxDamage= object1.Max;
            Durability=durability;
        }
        public int GetDamage()
        {
            return (MinDamage + MaxDamage) / 2;
        }

    }
}

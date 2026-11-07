using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Weapon
    {
        public string Name { get; }
        public Interval Damage { get; private set;}
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
            Damage = new Interval (minDamage, maxDamage);
            Durability=durability;
        }
        public int GetDamage()
        {
            return (Damage.Min + Damage.Max) / 2;
        }

    }
}

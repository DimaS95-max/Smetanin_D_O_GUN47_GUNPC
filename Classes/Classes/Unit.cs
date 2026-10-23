namespace Classes
{
    public class Unit
    {
        private float _health;

        public string Name { get;}
        
        public float Health => _health;

        public int Damage { get; }

        public float Armor { get; }


        public Unit() : this(name : "Unknown Unit")
        {
        }

        public Unit(string name)
        {
            Name = name;
        }

        public Unit (float armor, float health)
        {
            Armor = armor;
            _health = health;
        }

        public Unit (int damage)
        {
            Damage = damage;
        }

        public float GetRealHealth ()
        {
            return Health * (1f + Armor);
        }

        public bool SetDamage(float value)
        {
            _health = Health - value * Armor;

            if (Health <= 0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

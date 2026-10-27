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

        public Unit(string name, float health) : this(name: "Unknown Unit")
        {
            Name = name;
            _health = health;
            Armor = 0.6f;
        }

        public Unit (int maxDamage)
        {
            if (maxDamage <= 0)
            {
                maxDamage = 10;
                Console.WriteLine("Недопустимый максимальный дамаг");
            }

                var damage = new Interval(0, maxDamage);
            Damage = damage.Get;
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

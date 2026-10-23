namespace Classes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Подготовка к бою");
            Console.WriteLine("Введите имя бойца:");
            string name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Введено некорректное имя");
                return;
            }

            
            
            Console.WriteLine("Введите начальное здоровье бойца (10-100):");

            if (!int.TryParse(s: Console.ReadLine(), out int health))
            {
                Console.WriteLine("Введено некорректное число");
                return;
            }

            var object1 = new Unit(name);
            var object2 = new Unit(0.6f, health);
            var object3 = new Unit(5);

            Console.WriteLine("Введите полученный дамаг:");
            if (!int.TryParse(s: Console.ReadLine(), out int value))
            {
                Console.WriteLine("Введено некорректное число");
                return;
            }
            var returnHealth = object3.SetDamage(value);
            var RealHealth = object1.GetRealHealth();
            Console.WriteLine("Реальное здоровье бойца до атаки= {0}, после атаки боец мертв= {1}", RealHealth, returnHealth);
        }
    }
}

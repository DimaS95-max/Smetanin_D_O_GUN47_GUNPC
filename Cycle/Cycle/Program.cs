using System.ComponentModel;

namespace HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Задание 1
            Console.Write("Задание 1");
            Console.WriteLine();

            int n = 10;
            int i = 0;
            int[] a = new int[n];
            a[0] = 0;
            a[1] = 1;
            for (i = 2; i < a.Length; i++)
            {
                a[i] = a[i - 2] + a[i - 1]; // формула расчета Фибоначчи
            }
            for (i = 0; i < n; i++)
            {
                Console.Write("{0}\t", a[i]); // Выводим результат
            }
            Console.WriteLine();
            Console.WriteLine();

            // Задание 2
            Console.Write("Задание 2");
            Console.WriteLine();
            for (i = 2; i < 21; i++)
            {
                if (i % 2 == 0) // Проверяем, является ли число чётным
                {
                    Console.Write("{0}\t", i); // Выводим чётное число
                }
            }
            Console.WriteLine();
            Console.WriteLine();

            // Задание 3
            Console.Write("Задание 3");
            Console.WriteLine();
            int j = 0;
            for (i = 1; i < 11; i++)
            {
                for (j = 1; j < 6; j++)
                {
                    Console.Write("{0}x{1}={2}\t", j, i, j * i);
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Задание 4
            Console.Write("Задание 4");
            Console.WriteLine();
            string? password;
            do
            {
                Console.Write("Введите пароль:");
                password = Console.ReadLine();
                if (password != "qwerty")
                {
                    Console.WriteLine("Неверно");
                }

            } while (password != "qwerty");
            Console.WriteLine("Пароль введен верно");
        }
    }
}

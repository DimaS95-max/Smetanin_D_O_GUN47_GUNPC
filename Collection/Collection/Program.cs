using System.Xml.Linq;

namespace Collection
{
    internal class Program
    {
        private class ListTask
        {
            private readonly List<int> _listOfInts = new List<int>() { 1, 2, 3, 4, 5 };

            public void TaskLoop() // проверка ввода и вывод результата
            {
                Console.WriteLine("Какое число добавить в список");// Вводим число 
                if (!int.TryParse(Console.ReadLine(), out int a))
                {
                    Console.WriteLine("Error!"); // Ошибка
                    return;
                }
               
                _listOfInts.Add(a);// Добавляем число 

                for (int i = 0; i < _listOfInts.Count; i++) // Выводим список
                {
                    Console.WriteLine(_listOfInts[i]);
                }
                Console.WriteLine("Введите еще одно число"); // Вводим еще одно число 
                if (!int.TryParse(Console.ReadLine(), out int b))
                {
                    Console.WriteLine("Error!"); // Ошибка
                    return;
                }
                _listOfInts.Insert(3, b);
                for (int i = 0; i < _listOfInts.Count; i++) 
                {
                    Console.WriteLine(_listOfInts[i]);
                }
            }
        }
            private class DictionaryTask
            {
                // Создаём словарь для хранения данных
                Dictionary<string, int> students = new Dictionary<string, int>();

                public void TaskLoop()
                {
                    while (true)
                    {
                     Console.WriteLine("Введите имя студента или не вводите, чтобы завершить ввод");
                     string name = Console.ReadLine();

                     // Пустая строка означает завершение ввода
                     if (string.IsNullOrWhiteSpace(name))
                        break;
                    Console.WriteLine("Введите оценку студента от 2 дло 5");
                    // Проверка оценки: она должна быть целым числом от 2 до 5
                    if (!int.TryParse(Console.ReadLine(), out int mark) || mark < 2 || mark > 5)
                     {
                        Console.WriteLine("Ошибка: оценка должна быть целым числом от 2 до 5. Попробуйте снова.");
                        continue;
                     }
                     // Если студента ещё нет в словаре, добавляем его
                     if (!students.ContainsKey(name))
                     {
                        students[name] = mark;
                     }
                     else
                     {
                        // Если студент уже есть, обновляем оценку 
                        students[name] = mark;
                     }

                        Console.WriteLine($"Студент {name} добавлен/обновлён с оценкой {mark}.");
                    }

                while (true)
                {
                    Console.WriteLine("Введите имя студента, чтобы узнать его оценку, или ничего не вводите , чтобы завершить");

                    string Name = Console.ReadLine();

                    // Пустая строка означает завершение ввода
                    if (string.IsNullOrWhiteSpace(Name))
                        break;
                    // Если студента нет в словаре, выводим сообщение
                    if (!students.ContainsKey(Name))
                    {
                        Console.WriteLine($"Студента {Name} нет в списке");
                    }
                    else
                    {
                        // Если студент уже есть, выводим оценку 
                        Console.WriteLine($"Оценка студента {students[Name]}");
                    }
                }
                }
            }




            private class LinkedListTask
        {
            private class Node 
            {
                public int Value;
                public Node Next;
                public Node Prev;
            } // Узел списка

            public void TaskLoop()
            {
                Console.WriteLine("Введитке первое число");
                if (!int.TryParse(Console.ReadLine(), out int ab))
                {
                    Console.WriteLine("Error!"); // Ошибка
                    return;
                }
                var node1= new Node() { Value= ab };
                
                Console.WriteLine("Введитке второе число");
                if (!int.TryParse(Console.ReadLine(), out int bс))
                {
                    Console.WriteLine("Error!"); // Ошибка
                    return;
                }
                var node2 = new Node() { Value = bс };

                Console.WriteLine("Введитке третье число");
                if (!int.TryParse(Console.ReadLine(), out int сd))
                {
                    Console.WriteLine("Error!"); // Ошибка
                    return;
                }
                var node3 = new Node() { Value = сd };

                node1.Next = node2;
                node2.Next = node3;
                node3.Prev = node2;
                node2.Prev = node1;

                var next = node1;
                while (next != null) 
                {
                    Console.WriteLine(next.Value);
                    next= next.Next;
                }
                Console.WriteLine("-");
                next = node3;
                while (next != null)
                {
                    Console.WriteLine(next.Value);
                    next = next.Prev;
                }

                // проверка ввода и вывод результата
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter 1,2 or 3 to check task 1,2 or 3");
            if (!int.TryParse(Console.ReadLine(), out int task))
            {
                Console.WriteLine("Error!"); // Ошибка
                return;
            } 

            switch (task)
            {
                case 1:
                    CheckTaskFirst(); // Выполнение 1 задания в отдельном методе
                    break;
                case 2:
                    CheckDictionaryTask(); // Выполнение 2 задания в отдельном методе
                    break;
                case 3:
                    CheckLinkedListTask(); // Выполнение 2 задания в отдельном методе
                    break;
            }
        }

        private static void CheckTaskFirst()
        {
            var listTask = new ListTask();
            listTask.TaskLoop();
        }
        private static void CheckDictionaryTask()
        {
            var DictionaryTask = new DictionaryTask();
            DictionaryTask.TaskLoop();
        }

        private static void CheckLinkedListTask()
        {
            var LinkedListTask = new LinkedListTask();
            LinkedListTask.TaskLoop();
        }

    }

}

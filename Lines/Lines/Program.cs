using System.Text;
using System.Xml.Linq;

namespace Lines
{
    internal class Program
    {
        public static string Concatenate(string str1, string str2)
        {
            str1= $"{str1} ";
            // Соединяем слова
            return String.Concat(str1, str2);
        }

        public static string GreetUser(string name, int age)
        {
            return $"Hello, {name}!\n" + 
                   $"You are{age} years old.";
        }

        public static string ReturningRows(string startLine)
        {
            string result = $"Количество символов: {startLine.Length}\n" +
                            $"Верхний регистр: {startLine.ToUpper()}\n" +
                            $"Нижний регистр: {startLine.ToLower()}";
            return result;
        }

        public static string GetFirstFiveChars(string input)
        {
            return input.Substring(0, 5);
        }

        public static StringBuilder BuildSentence(string[] words)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < words.Length; i++)
            {
                // Добавляем слово и пробел
                sb.Append(words[i]);
                sb.Append(' ');
            }
            return sb;
        }

        public static string ReplaceWords(string inputString, string wordToReplace, string replacementWord)
        {
            // Используем встроенный метод Replace для замены всех вхождений
            return inputString.Replace(wordToReplace, replacementWord);
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер задания от 1 до 6");
            if (!int.TryParse(Console.ReadLine(), out int task))
            {
                Console.WriteLine("Error!"); // Ошибка
                return;
            }
            switch (task)
            {
                case 1:
                    Console.WriteLine("Введите первое слово");
                    
                    string str1 = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(str1))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }

                    Console.WriteLine("Введите второе слово");
                    
                    string str2 = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(str2))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }
                    
                    Console.WriteLine(Concatenate(str1, str2)); // Выполнение задания в отдельном методе
                    break;


                case 2:
                    Console.WriteLine("Введите имя");
                    string name = Console.ReadLine();
                    
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }

                    Console.WriteLine("Введите возраст");
                    
                    if (!int.TryParse(Console.ReadLine(), out int age))
                    {
                        Console.WriteLine("Error!"); // Ошибка
                        break;
                    }
                    Console.WriteLine(GreetUser(name, age));

                    break;


                case 3:
                    Console.WriteLine("Введите строку");
                    string startLine = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(startLine))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }
                    Console.WriteLine(ReturningRows(startLine));
                    break;


                case 4:
                    Console.WriteLine("Введите строку");
                    string input = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(input))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }
                    Console.WriteLine(GetFirstFiveChars(input));
                    break;


                case 5:
                    string[] words = new string[5] {"I", "like", "playing", "strategy","games." };

                    Console.WriteLine(BuildSentence(words).ToString());
                    break;


                case 6:
                    Console.WriteLine("Введите строку");
                    string inputString = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(inputString))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }

                    Console.WriteLine("Введите слово, которое нужно заменить");
                    string wordToReplace = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(wordToReplace))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }

                    Console.WriteLine("Введите слово для замены");
                    string replacementWord = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(replacementWord))
                    {
                        Console.WriteLine("Ввод не может быть пустым.");
                        break;
                    }

                    Console.WriteLine(ReplaceWords(inputString, wordToReplace,replacementWord));
                    break;
            }   
        }
    }
}

using Task2_1_1;

namespace Tasks2_2_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Индексатор
            Console.WriteLine("Демонстрация индексатора:");
            StringCreator str = new StringCreator('H', 'e', 'l', 'l', 'o', '!');
            Console.WriteLine($"Исходная строка: {str} \nВывожу на консоль элемент с индексом 2");
            Console.WriteLine(str[2]);

            Console.WriteLine();

            //Конкатенация
            Console.WriteLine("Демонстрация конкатенации:");
            StringCreator str2 = new StringCreator(' ', 'w', 'o', 'r', 'l', 'd', '!');
            Console.WriteLine($"Первая строка: {str}\nВторая строка: {str2}");
            Console.WriteLine($"Результат: {str + str2}");

            Console.WriteLine();

            //Substring
            Console.WriteLine("Демонстрация Substring:");
            Console.WriteLine($"Исходная строка: {str2} беру подстроку с начальным индексом 1, с длиной 3");
            StringCreator substrings = str2.Substring(1, 3);
            Console.WriteLine($"Результат: {substrings}");

            Console.WriteLine();

            //Split
            Console.WriteLine("Демонстрация Split по ! знаку:");
            StringCreator str3 = new StringCreator(' ', 'i', 't', 's', 'm', 'y');
            StringCreator str4 = str + str2 + str3;
            Console.WriteLine($"Исходная строка: {str4}");
            char[] separators = new char[] { '!' };
            StringCreator[] strs = StringCreator.MySplit(str4, separators);
            Console.WriteLine("Результат сплита:");
            for (int i = 0; i < strs.Length; i++)
            {
                Console.WriteLine(strs[i]);
            }

            Console.WriteLine();

            //Поиск символов
            Console.WriteLine($"Исходная строка: {str}");
            Console.WriteLine("Демонстрация поиска символа l и возврат его индекса:");
            Console.WriteLine(str.FindCharIndex('l'));
            Console.WriteLine("Демонстрация поиска символа h и возврат bool:");
            Console.WriteLine(str.FindChar('h'));

            Console.WriteLine();

            //Приведение к массиву
            Console.WriteLine("Демонстрация приведения к массиву:");
            char[] array = str.ToCharArray();
            Console.WriteLine(string.Join(',', array));

            Console.WriteLine();

            //Trim
            Console.WriteLine("Демонстрация Trim:");
            Console.WriteLine(str2);
            StringCreator trimming = str2.Trim();
            Console.WriteLine(trimming);

            Console.WriteLine();

            //Equals, ==, !=
            Console.WriteLine("Демонстрация сравнения:");
            StringCreator first = new StringCreator('h', 'i');
            StringCreator second = new StringCreator('h', 'i');
            StringCreator third = new StringCreator('f', 'g', 'd');
            Console.WriteLine($"hi == hi - {first==second}");
            Console.WriteLine($"hi != hi - {first != second}");
            Console.WriteLine($"hi == fgd - {first == third}");
            Console.WriteLine($"hi != fgd - {first!= third}");
            Console.WriteLine($"hi eqauls second - {first.Equals(second)}");

            Console.WriteLine();

            //Поиск цифр в строке
            Console.WriteLine("Демонстрация поиска цифр в строке:");
            StringCreator digitStr = new StringCreator('H', '2', 'e', 'l', 'l', 'o', '!', '5', '2', '9');
            Console.WriteLine($"Исходная строка: {digitStr}");
            int[] digitFromStr = digitStr.GetDegit();
            Console.WriteLine(string.Join(',', digitFromStr));

        }
    }
}
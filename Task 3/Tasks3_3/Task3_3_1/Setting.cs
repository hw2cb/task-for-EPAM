using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_1
{
    internal static class Setting
    {
        //класс настройки, отвечает за настройку массива
        /* Методы:
         * WriteArray - отвечает за ввод массива пользователем
         * SettingGenerationArray - отвечает за ввод длины массива, мин и макс значения при генерации массива
         * Length - длина массива (по дефолту 10)
         * MinNumber - минимальное число (по дефолту 3)
         * MaxNumber - максимальное число (по дефолту 577)
         */
        public static int Length { get; private set; } = 10;
        public static int MinNumber { get; private set; } = 3;
        public static int MaxNumber { get; private set; } = 577;
        public static void StartSettings()
        {
            Console.WriteLine("Нажмите Y, если хотите ввести массив в ручную");
            Console.WriteLine("Нажмите N, если хотите настроить генерацию массива");
            ConsoleKey key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Y)
            {
                WriteArray();
            }
            else if (key == ConsoleKey.N)
            {
                SettingGenerationArray();
            }
        }
        private static void WriteArray()
        {
            List<int> array = new List<int>();
            Console.WriteLine("Начинайте вводить свои числа. После ввода числа, нажимай Enter что бы сохранить его. Что бы остановиться, нажмите на ESC!");
            string buff = "";
            while(true)
            {
                //написал вот такой код что бы вводить числа в массив и иметь возможность выходить из самого ввода клавишей ESC
                
                ConsoleKeyInfo readKey = Console.ReadKey(true);

                if(readKey.Key == ConsoleKey.Enter)
                {
                    if(buff != "")
                    {
                        array.Add(int.Parse(buff));
                        buff = "";
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Вы не ввели ниче!");
                        continue;
                    }

                }
                else if(readKey.Key == ConsoleKey.Escape)
                {
                    buff = "";
                    Console.Clear();
                    break;
                    //если вышел

                }
                //если символ число
                else if(char.IsDigit(readKey.KeyChar))
                {
                    //добавляю в строку числа, после нажатия Enter строка будет спаршена и добавлена в массив, затем отчищена
                    buff += readKey.KeyChar;
                    Console.Write(readKey.KeyChar);
                }
            }
            Startup.SetArray(array.ToArray());

        }
        private static void SettingGenerationArray()
        {
            int length;
            int min;
            int max;
            Console.WriteLine("Введите длину массива: ");
            while (!int.TryParse(Console.ReadLine(), out length))
            {
                Console.WriteLine("Ошибка ввода!");
            }

            Console.WriteLine("Введите минимальное возможное число, которое может содержаться в массиве: ");
            while (!int.TryParse(Console.ReadLine(), out min))
            {
                Console.WriteLine("Ошибка ввода!");
            }

            Console.WriteLine("Введите максимальное возможное число, которое может содержаться в массиве: ");
            while (!int.TryParse(Console.ReadLine(), out max))
            {
                Console.WriteLine("Ошибка ввода!");
            }
            Length = length;
            MinNumber = min;
            MaxNumber = max;
            Startup.RefreshArray();

        }

    }
}

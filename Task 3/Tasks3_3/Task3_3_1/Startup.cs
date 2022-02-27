using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_1
{
    internal static class Startup
    {
        //класс отвечает за консольный интерфейс
        /*
         * SetArray() -установка массива
         * RefreshArray - запуск генерации массива
         * MoveToNextTask - вспомогательный метод, позволяет отрисовывать дальнейшее выполнение программы
         * PrintAndStartMethods - вспомогательный метод, позволяет напечатать массив и консольный вывод (интерфейс)
         * FillArray - заполнение массива
         * PrintArray - печать массива
         * ActionWithEveryElement - делегат, для методов из Actions
         * sourceArray - массив чисел, над которым производятся действия
         */
        public delegate int ActionWithEveryElement(int element);
        private static int[] sourceArray;
        static Startup()
        {
            sourceArray = FillArray();
        }

        public static void Run()
        {
            while(true)
            {
                Console.WriteLine("Делегаты.");
                Console.WriteLine("\n1. Первый метод, Multiply. Умножает каждый элемент массива на 2");
                PrintAndStartMethods(new ActionWithEveryElement(Actions.Multiply));
                MoveToNextTask();

                Console.WriteLine("\n2. Второй метод, PowTwo. Умножает каждый элемент массива сам на себя");
                PrintAndStartMethods(new ActionWithEveryElement(Actions.PowTwo));
                MoveToNextTask();

                Console.WriteLine("\n2. Третий метод, Divide. Каждый элемент массива делится на 2");
                PrintAndStartMethods(new ActionWithEveryElement(Actions.Divide));
                MoveToNextTask();

                Console.WriteLine("Методы расширения");
                Console.WriteLine("\n1. Метод расширения, возвращающий сумму всех элементов.");
                PrintArray(sourceArray);
                Console.WriteLine($"Сумма всех элементов: {sourceArray.GetSumElements()}");
                MoveToNextTask();

                Console.WriteLine("\n2. Метод расширения, возвращающий среднее значение.");
                PrintArray(sourceArray);
                Console.WriteLine($"Среднее значение: {sourceArray.GetAverage()}");
                MoveToNextTask();

                Console.WriteLine("\n3. Метод расширения, возвращающий самое часто повторяемое число в массиве.");
                Console.WriteLine("Для демонстрации, создал более подходящий массив:");
                int[] arrayForFrequencyMethods = new int[] { 1, 1, 1, 2, 2, 5, 6, 7 };
                PrintArray(arrayForFrequencyMethods);
                Console.WriteLine($"Наиболее повторяемое число: {arrayForFrequencyMethods.GetFrequency()}");
                MoveToNextTask();

                Console.WriteLine("Нажмите Y если хотите запустить программу по новой (массив поменяет значения элементов)");
                Console.WriteLine("Нажмите N если хотите настроить программу (возможность настроить длины массивов, рандомизацию)");
                Console.WriteLine("Нажмите другую клавишу для выхода");
                ConsoleKey key = Console.ReadKey(true).Key;
                if(key == ConsoleKey.Y)
                {
                    Console.Clear();
                    RefreshArray();
                    continue;
                }
                else if(key == ConsoleKey.N)
                {
                    Console.Clear();
                    Setting.StartSettings();
                }
                else
                {
                    break;
                }
            }
            


        }
        public static void SetArray(int[] array)
        {
            sourceArray = array;
        }
        public static void RefreshArray()
        {
            sourceArray = FillArray();
        }

        #region Вспомогательные методы для работы (FillArray and PrintArray)
        private static void MoveToNextTask()
        {
            Console.WriteLine("Нажмите любую клавишу для продолжения");
            Console.ReadLine();
            Console.Clear();
        }
        private static void PrintAndStartMethods(ActionWithEveryElement function)
        {
            //что бы не повторять 4 строчек кода
            Console.WriteLine("Исходный массив: ");
            PrintArray(sourceArray);
            sourceArray.DoAction(function);
            Console.WriteLine("Состояние массива после выполнения метода: ");
            PrintArray(sourceArray);
        }
        private static int[] FillArray()
        {
            //метод заполнения исходного массива
            Random random = new Random();
            int capacity = Setting.Length;
            int [] resultArray = new int[capacity];
            for(int i=0; i<capacity; i++)
            {
                resultArray[i] = random.Next(Setting.MinNumber, Setting.MaxNumber);
            }
            return resultArray;
        }
        private static void PrintArray(int[] array)
        {
            foreach(var item in array)
            {
                Console.Write(item);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        #endregion
    }
}

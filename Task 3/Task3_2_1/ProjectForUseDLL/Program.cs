
using DynamicCollections;

namespace Task3_2_1
{
    internal class Program
    {
        //клиентский код, использующий мою dll с моей коллекцией
        public static void Main(string[] args)
        {
            #region Конструктор без параметров (Задание 1)
            Console.WriteLine("Демонстрация 1 задания");
            DynamicArray<int> first = new DynamicArray<int>();
            Console.WriteLine($"Capacity:{first.Capacity}");
            Console.WriteLine($"Length: {first.Length}");
            #endregion

            #region Конструктор с одним параметром (указанная емкость) (Задание 2)
            Console.WriteLine("\nДемонстрация 2 задания");
            DynamicArray<int> second = new DynamicArray<int>(5);
            Console.WriteLine($"Capacity:{second.Capacity}");
            Console.WriteLine($"Length: {second.Length}");
            #endregion

            #region Конструктор, принимающий коллекцию и создает массив нужного размера и копирует в него все элементы (Здание 3)
            Console.WriteLine("\nДемонстрация 3 задания");
            IEnumerable<int> third = new List<int>(9) { 5, 4, 6, 6, 7, 1, 2 };
            Console.WriteLine("Коллекция List, ссылка которого является IEnumerable, элементы: ");
            PrintArray(third);
            Console.WriteLine("Создал свою коллекцию, передал в конструктор List");
            DynamicArray<int> thirdDynamicArray = new DynamicArray<int>(third);
            Console.WriteLine($"Capacity: {thirdDynamicArray.Capacity}");
            Console.WriteLine($"Length: {thirdDynamicArray.Length}");
            Console.WriteLine("Элементы в моей коллекции: ");
            PrintArray<int>(thirdDynamicArray);
            #endregion

            #region Проверка метода Add (Задание 4)
            Console.WriteLine("\nПроверка метода Add():");
            Console.WriteLine("Элементы динамического массива: ");
            DynamicArray<int> myArray = new DynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            PrintArray(myArray);
            Console.WriteLine($"Изначальная Capacity: {myArray.Capacity}");
            Console.WriteLine($"Изначальная Length: {myArray.Length}");
            myArray.Add(1);
            Console.WriteLine($"После метода Add() Capacity: {myArray.Capacity}");
            Console.WriteLine($"После метода Add() Length: {myArray.Length}");
            #endregion

            #region Метод AddRange (Задание 5)
            Console.WriteLine("\nДемонстрация задания 5 (метод AddRange) ");
            Console.WriteLine("Создал свою коллекцию: ");
            DynamicArray<int> fourth = new DynamicArray<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Capacity:{fourth.Capacity}");
            Console.WriteLine($"Length: {fourth.Length}");
            PrintArray(fourth);
            Console.WriteLine("Создал list:");
            List<int> fourthList = new List<int>() { 5, 4, 6, 6, 7, 1, 2 };
            Console.WriteLine($"Capacity Lists: {fourthList.Capacity}");
            Console.WriteLine($"Count lists: {fourthList.Count}");
            PrintArray(fourthList);
            fourth.AddRange(fourthList);
            Console.WriteLine("Состояние моей изначальной коллекции после метода AddRange(list)");
            Console.WriteLine($"Capacity:{fourth.Capacity}");
            Console.WriteLine($"Length: {fourth.Length}");
            PrintArray(fourth);
            #endregion

            #region Метод Remove (задание 6)
            Console.WriteLine("\nДемонстрация задания 6");
            Console.WriteLine("Исходная коллекция: ");
            DynamicArray<int> fifth = new DynamicArray<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine($"Capacity:{fifth.Capacity}");
            Console.WriteLine($"Length: {fifth.Length}");
            PrintArray(fifth);
            fifth.Remove(4);
            Console.WriteLine("Состояние после метода Remove(4);");
            Console.WriteLine($"Capacity:{fifth.Capacity}");
            Console.WriteLine($"Length: {fifth.Length}");
            PrintArray(fifth);
            #endregion

            #region Метод Insert (Задание 7)
            Console.WriteLine("\nДемонстрация задания 7");
            DynamicArray<int> sixth = new DynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            Console.WriteLine("Применяю худший вариант, когда длина массива-хранилища заканчивается: ");
            Console.WriteLine($"Capacity:{sixth.Capacity}");
            Console.WriteLine($"Length: {sixth.Length}");
            PrintArray(sixth);
            sixth.Insert(5, 15);
            Console.WriteLine("Состояние моей коллекции после метода Insert(5, 15) где 5 - индекс, 15 значение");
            Console.WriteLine($"Capacity:{sixth.Capacity}");
            Console.WriteLine($"Length: {sixth.Length}");
            PrintArray(sixth);
            #endregion

            #region Индексатор
            Console.WriteLine("\nИндексатор");
            DynamicArray<int> dynamicArray = new DynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            PrintArray(dynamicArray);
            Console.WriteLine($"Индекс 1: {dynamicArray[1]}");
            Console.WriteLine($"Индекс 6: {dynamicArray[6]}");
            #endregion

            //Задания под *
            Console.WriteLine("Задания с *");
            #region Доступ к элементам с конца при использовании отрицательного индекса (Задание 1)
            //-1(последний), -2(предпоследний) и тд
            Console.WriteLine("\nДемонстрация задания 1 (доступ с конца)");
            DynamicArray<int> endAccess = new DynamicArray<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            PrintArray(endAccess);
            Console.WriteLine($"Индекс -1: {endAccess[-1]}");
            Console.WriteLine($"Индекс -2: {endAccess[-2]}");
            Console.WriteLine($"Индекс -5: {endAccess[-5]}");
            #endregion

            #region Проверка задания под *, изменяемое свойство Capacity (Задание 2)
            Console.WriteLine("\nДемонстрация задания 2 (изменяемое свойство Capacity)");
            DynamicArray<int> forShowCapacity = new DynamicArray<int>() { 1, 2, 3, 5, 6, 7, 8, 9 };
            Console.WriteLine($"Изначально Capacity: {forShowCapacity.Capacity}");
            Console.WriteLine($"Изначально Length: {forShowCapacity.Length}");
            PrintArray(forShowCapacity);
            forShowCapacity.Capacity = 3;
            Console.WriteLine("Установил Capacity = 3 ");

            Console.WriteLine($"После изменений Capacity: {forShowCapacity.Capacity}");
            Console.WriteLine($"После изменений Length: {forShowCapacity.Length}");
            PrintArray(forShowCapacity);

            #endregion
            #region Реализация ICloneable (Задание 3)
            Console.WriteLine("\nДемонстрация задания 3, реализация ICloneable");
            Console.WriteLine("Создаю первую коллекцию, состояние ее:");
            DynamicArray<int> test = new DynamicArray<int>() { 1, 2, 3, 4 };
            Console.WriteLine($"Capacity исходного:{test.Capacity}");
            Console.WriteLine($"Length исходного: {test.Length}");
            PrintArray(test);
            DynamicArray<int> copy = (DynamicArray<int>)test.Clone();
            Console.WriteLine("Копирование...");
            Console.WriteLine($"Capacity копированного:{test.Capacity}");
            Console.WriteLine($"Length копированного: {test.Length}");
            PrintArray(copy);
            #endregion

            #region ToArray() (Задание 4);
            Console.WriteLine("\nДемонстрация задания 4, метод ToArray()");
            Console.WriteLine("Создаю коллекцию, состояние ее:");
            DynamicArray<int> inArray = new DynamicArray<int>() { 1, 2, 3, 4 };
            Console.WriteLine($"Capacity исходного:{inArray.Capacity}");
            Console.WriteLine($"Length исходного: {inArray.Length}");
            PrintArray(inArray);
            int[] array = inArray.ToArray();
            Console.WriteLine("Метод ToArray()");
            Console.WriteLine(array.GetType());
            PrintArray(array);
            #endregion

            #region Цикличная коллекция (Задание 5)
            Console.WriteLine("\nДемонстрация цикличной коллекции, задание 5 ");
            CycledDynamicArray<int> d = new CycledDynamicArray<int>() { 1, 2, 3, 4 };
            Console.WriteLine($"Capacity: {d.Capacity}");
            Console.WriteLine($"Length: {d.Length}");
            Console.WriteLine("Специально написал метод, который медленно выводит элементы");
            SlowPrintArray(d);
            #endregion


        }
        private static void PrintArray<T>(IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(' ');
            }
            Console.WriteLine();
        }
        private static void SlowPrintArray<T>(IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Console.Write(item);
                Console.Write(' ');
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }
}
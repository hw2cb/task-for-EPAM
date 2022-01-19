/*TASK 1.1.7
 * ARRAY PROCESSING
 * Написать программу, которая генерирует случайным образом элементы массива
 * (число элементов в массиве и их тип определяются разработчиком), определяет для него максимальное
 * и минимальное значения, сортирует массив и выводит полученный результат на экран
 * 
 */

namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = NewRandomArray(10);
            Console.WriteLine("Исходный, заполненный массив: ");
            foreach(var element in array)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine($"Максимальное значение в массиве: {MaxValue(array)}");
            Console.WriteLine($"Минимальное значение в массиве: {MinValue(array)}");

            int[] sortedArray = QuickSort(array, 0, array.Length-1);
            Console.WriteLine("Отсортированный массив: ");
            foreach(var element in sortedArray)
            {
                Console.WriteLine(element);
            }

        }
        public static int[] NewRandomArray(int len)
        {
            //метод создания и заполнения массива
            Random random = new Random();
            int [] array = new int[len];

            for (int i = 0; i < len; i++)
            {
                array[i] = random.Next(0, 1000);
            }
            return array;
        }
        public static int MaxValue(int[] array)
        {
            int maxValue = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                }
            }
            return maxValue;
        }
        public static int MinValue(int[] array)
        {
            int minValue = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                }
            }
            return minValue;
        }
        public static int [] QuickSort(int[] array, int left, int right)
        {
            //критерий выхода из рекурсии
            if(left>=right)
            {
                return array;
            }
            //быстрая сортировка
            int pivotIndex = GetPivot(array, left, right);

            //сортировка левого подмассива
            QuickSort(array, left, pivotIndex - 1);
            //сортировка правого подмассива
            QuickSort(array, pivotIndex + 1, right);

            return array;
        }
        private static int GetPivot(int [] array, int left, int right)
        {
            int pivot = left - 1;
            for (int i = left; i < right; i++)
            {
                //в данном случае array[right] это опорный элемент, конечный элемент массива
                if(array[i]<array[right])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }
            pivot++;
            Swap(ref array[pivot], ref array[right]);
            return pivot;
        }
        private static void Swap(ref int firstElement, ref int secondElement)
        {
            //метод перестановки
            int temp = firstElement;
            firstElement = secondElement;
            secondElement = temp;
        }

        
    }
}
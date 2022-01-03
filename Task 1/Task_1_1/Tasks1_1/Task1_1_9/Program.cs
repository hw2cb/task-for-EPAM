/*TASK 1.1.9
 * NON-NEGATIVE SUM
 * Написать программу, которая определяет сумму неотрицательных элементов в одномерном массиве. 
 * Число элементов в массиве и их тип определяются разработчиком.
 * 
 */

namespace Tasks1_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[] array = FillArray(10);
            Console.WriteLine(String.Join(", ", array));
            Console.WriteLine($"Сумма неотрицательных элементов: {NegativeSum(array)}");
        }
        public static int NegativeSum(int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if(array[i]>0)
                    sum+=array[i];
            }
            return sum;
        }
        public static int[] FillArray(int size)
        {
            Random r = new Random();
            int[] res = new int[size];
            for (int i = 0; i < size; i++)
            {
                res[i] = r.Next(-7, 7);
            }
            return res;
        }
    }
}
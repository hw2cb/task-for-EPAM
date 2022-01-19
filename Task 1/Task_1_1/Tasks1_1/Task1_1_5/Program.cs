/*TASK 1.1.5
 * SUM OF NUMBERS
 * Напишите программу, которая выводит на экран сумму всех чисел меньше 1000
 * И кратных 3 или 5.
 * 
 * Пример (меньше 10) 3, 5, 6, 9 их сумма 23.
 * 
 */
using SD;

namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(Sum());
        }
        public static int Sum()
        {
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            }
            return sum;
        }
    }
}
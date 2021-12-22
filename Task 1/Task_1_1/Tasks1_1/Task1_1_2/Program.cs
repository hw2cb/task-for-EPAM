/*
 * Task 1.1.2
 * TRIANGLE
 * Написать программу, которая запрашивает с клавиатуры число N и выводит
 * на экран следующее изображение, состоящее из N строк:
 * 
 * *
 * * *
 * * * *
 * * * * *
 * * * * * *
 * * * * * * *
 * * * * * * * *
 */

namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк: ");
            int result;
            while(!int.TryParse(Console.ReadLine(), out result) || result <=0)
            {
                Console.WriteLine("Введите корректное число строк: ");
            }

            for (int i = 0; i < result; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    Console.Write("* ");
                }
                Console.WriteLine();    
            }
        }
    }
}

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

using SD;

namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberN = SD.SD.EnterNumber();

            for (int i = 0; i < numberN; i++)
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

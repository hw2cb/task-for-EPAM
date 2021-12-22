/* TASK 1.1.4
 * X-MAX TREE
 * Написать программу, которая запрашивает с клавиатуры число N и
 * выводит на экран следующее изображение состоящее из N треугольников:
 *                  *
 *                  *
 *                 ***
 *                  *
 *                 ***
 *                *****
 *                  *
 *                 ***
 *                *****
 *               *******
 *                  *
 *                 ***
 *                *****
 *               *******
 *              ********* 
 * 
 */


using SD;

namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberN = SD.SD.EnterNumber();
            for (int i = numberN; i >= 0; i--)
            {
                int countStar = 1;
                int countSpace = numberN;
                for (int j = 0; j <= numberN-i; j++)
                {
                    //расставляем пробелы
                    for (int k = 0; k < countSpace; k++)
                    {
                        Console.Write(' ');
                    }
                    //звезды
                    for(int k = 0; k < countStar; k++)
                    {
                        Console.Write('*');
                    }
                    countStar+=2;
                    countSpace--;
                    Console.WriteLine();
                }
            }
        }
    }
}
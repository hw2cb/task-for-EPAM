/*TASK 1.1.3
 * ANOTHER TRIANGLE
 * Написать программу, которая запрашивает с клавиатуры число N и выводит
 * на экран следующее изображение, состоящее из N строк:
 * 
 *           *
 *          ***
 *         *****
 *        *******
 *       *********
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
            int countStar = 1;
            //количество пробелов в начальном состоянии должно быть на единицу меньше чем количество строк
            int countSpace = numberN - 1;

            for (int i = 0; i < numberN; i++)
            {
                //ставим пробелы
                for (int j = 0; j < countSpace; j++)
                {
                    Console.Write(' ');
                }
                //ставим звездочки
                for (int k = 0; k < countStar; k++)
                {
                    Console.Write('*');
                }
                Console.WriteLine();
                //данная итерация увеличивает количество звезд на 2 с новой строкой
                countStar+=2; 
                countSpace--;

            }
        }
    }
}

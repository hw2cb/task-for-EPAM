/*TASK 1.1.10
 * 2D ARRAY
 * Элемент двумерного массива считается стоящим на четной позиции, если сумма номеров его позиций
 * по обеим размерностям является четным числом ([1,1] - четная позиция, [1,2] - нет.
 * Опрделеить сумму элементов массива, стоящих на четных позициях.
 * 
 * 
 */

namespace Tasks1_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int[,] array2D = Fill2DArray(4);
            Console.WriteLine("Исходный массив: ");
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    Console.Write($"{array2D[i, j]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine($"Сумма элементов стоящих на четных позициях: {CustomSum(array2D)}");
        }
        public static int CustomSum(int [,] array2D)
        {
            int sum = 0;
            for (int i = 0; i < array2D.GetLength(0); i++)
            {
                for (int j = 0; j < array2D.GetLength(1); j++)
                {
                    if((i+j)%2==0)
                    {
                        sum+=array2D[i, j];
                    }
                }

            }
            return sum;
        }
        public static int[,] Fill2DArray(int size)
        {
            Random r = new Random();
            int[,] res = new int[size,size];
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    res[i, j] = r.Next(0, 10);
                }
                
            }
            return res;
        }
    }
}
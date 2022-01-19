/*TASK 1.1.8
 * NO POSITIVE
 * Написать программу, которая заменяет все положительные элементы в трехмерном массиве на нули.
 * Число элементом в массиве и их тип определяется разработчиком.
 * 
 * 
 */


namespace Tasks1_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[,,] array3D = Fill3DArray(3);
            Console.WriteLine("Исходный массив: ");
            WriteInConsole(array3D);
            int[,,] array3DNoPositive = NoPositive(array3D);
            Console.WriteLine("Модифицированный массив: ");
            WriteInConsole(array3DNoPositive);

        }
        public static void WriteInConsole(int[,,] array3D)
        {
            //вывод на консоль
            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        Console.Write($"{array3D[i, j, k]} ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }
        public static int[,,] NoPositive(int[,,]array3D)
        {
            //метод, релизующий выполнение задачи
            for (int i = 0; i < array3D.GetLength(0); i++)
            {
                for (int j = 0; j < array3D.GetLength(1); j++)
                {
                    for (int k = 0; k < array3D.GetLength(2); k++)
                    {
                        if (array3D[i, j, k] > 0)
                            array3D[i, j, k] = 0;
                    }
                }
            }
            return array3D;
        }
        public static int [,,] Fill3DArray(int count)
        {
            //заполнение массива
            Random r = new Random();
            int[,,] res = new int[count, count, count];
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < count; j++)
                {
                    for (int k = 0; k < count; k++)
                    {
                        res[i, j, k] = r.Next(-5, 5);
                    }
                }
            }

            return res;
        }
       
    }
}
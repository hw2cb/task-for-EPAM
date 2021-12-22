/*
 * Task 1.1.1
 * RECTANGLE
 * Написать программу, которая определяетс площадь прямоугольника со сторонами a и b.
 * Если пользователь вводит некорректные значения (отрицательные или ноль), должно выдаваться сообщение об ошибке.
 * Возможность ввода пользователем строки "абвгд" или нецелых чисел игнорировать.
 */

namespace Tasks1_1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            //Цикл while обеспечит повторный ввод при некорректных значениях
            while(!Enter())
            {
                Console.WriteLine("Некорректный ввод!");
            }
        }
        private static bool Enter()
        {
            //метод ввода чисел в программу
            Console.WriteLine("Введите сторону a: ");
            int.TryParse(Console.ReadLine(), out int a);
            Console.WriteLine("Введите сторону b: ");
            int.TryParse(Console.ReadLine(), out int b);

            if (a <= 0 || b <= 0) return false;

            GetResult(a, b);
            return true;
        }
        private static void GetResult(int a, int b)
        {
            //вспомогательный метод вывода на консоль результата
            Console.WriteLine($"Площаль прямоугольника со сторонами a:{a} b:{b} = {a * b}");
        }
    }
}
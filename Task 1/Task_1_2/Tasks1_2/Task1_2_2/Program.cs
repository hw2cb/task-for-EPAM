/*TASK 1.2.2
 * DOUBLER
 * 
 * Напишите программу, которая удваивает в первой введенной строке все символы,
 * принадлежащие второй введенной строке.
 * 
 */

using System.Text;

namespace Tasks1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите первую строку: ");
            string firstStr = Console.ReadLine();
            Console.WriteLine("Введите вторую строку: ");
            string secondStr = Console.ReadLine();
            Console.WriteLine(Doubler(firstStr, secondStr));

        }
        public static string Doubler(string firstString, string secondString)
        {
            string doublerStr = "";
            char[] splittings = secondString.ToCharArray();

            for (int i = 0; i < firstString.Length; i++)
            {
                if(splittings.Contains(firstString[i]))
                {
                    doublerStr += firstString[i];
                }
                doublerStr += firstString[i];
            }
            return doublerStr;
        }
    }
}
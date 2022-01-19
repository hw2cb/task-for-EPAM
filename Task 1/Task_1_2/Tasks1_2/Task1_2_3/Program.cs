/*TASK 1.2.3
 * LOWERCASE
 * 
 * Напишите программу, которая считает количество слов, начинающихся с маленькой буквы.
 * Предлоги, союзы и междометия считаются словами. Финальную точку в предложении можно не учитывать
 * 
 */


namespace Tasks1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Введите предложение: ");
            string str = Console.ReadLine();
            Console.WriteLine($"Количество слов с заглавной буквы: {GetCountLowercase(str)}");

        }
        public static int GetCountLowercase(string str)
        {
            int count = 0;

            char[] separators = new char[] { ',', '?', '.', ':', '!', '"', ';', ' ' };
            string[] words = str.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            foreach(var word in words)
            {
                if(char.IsLower(word[0]))
                {
                    count++;
                }
            }
            return count;
        }

    }
}
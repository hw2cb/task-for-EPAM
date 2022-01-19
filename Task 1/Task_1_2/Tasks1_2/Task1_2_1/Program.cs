/*TASK 1.2.1
 * AVERAGES
 * Напишите программу, которая определяет среднюю длину слова во введенной текстовой строке.
 * Учтите, что символы пунтуации на длину слов влиять не должны. Не стоит искать каждый символ разделитель вручную
 * используйте стандартные методы классов String и Char. Регулярные выражение не использовать.
 * В случае дробного результата можете оставить таким, можете округлить. Оставьте комментарий в коде,
 * указывающий, какое решение вы приняли.
 * 
 */


namespace Tasks1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(AverageCharWord(str)); 
        }
        private static double AverageCharWord(string str)
        {
            int sumChars = 0;

            char[] separators = new char[] { ',', '?', '.', ':', '!', '"', ';', ' ' };
            string[] words = str.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var word in words)
            {
                sumChars += word.Length;
            }
            return (double)sumChars/words.Length;
        }
    }
}
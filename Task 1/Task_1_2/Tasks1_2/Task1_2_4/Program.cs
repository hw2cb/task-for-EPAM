/*TASK 1.2.4
 * VALIDATOR
 * 
 * Напишите программу, которая заменяет первую букву первого слова в предложении на заглавную.
 * В качестве окончания предложения можете считать только . ? ! Многоточие и ?! можно опустить.
 */

using System.Text;

namespace Tasks1_2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Console.WriteLine(Validator(str));

        }
        public static string Validator(string str)
        {
            string res = "";
            char[] separators = new char[] { '?', '.', '!', ';'};
            string[] splitting = MySplit(str, separators);

            for (int i = 0; i < splitting.Length; i++)
            {
                res += SentenceValidation(splitting[i]);
                res += " ";
            }
            return res;
        }
        private static string[] MySplit(string str, char [] separators)
        {
            //метод разделение с сохранением разделителя
            int startIndex = 0;
            //использую хэшсет дабы защититься от попытки сунуть в метод повторяющиеся разделители
            HashSet<char> sep = new HashSet<char>(separators);
            List<string> res = new List<string> ();

            for (int i = 0; i < str.Length; i++)
            {
                if(sep.Contains(str[i]))
                {
                    res.Add(str.Substring(startIndex, (i - startIndex)+1));
                    startIndex = i + 2;
                }
            }
            return res.ToArray();
        }
        private static string SentenceValidation(string str)
        {
            StringBuilder newStr = new StringBuilder();
            if (char.IsLower(str[0]))
            {
                newStr = new StringBuilder(str);
                newStr[0] = char.ToUpper(str[0]);
            }
            else
                newStr.Append(str);
            return newStr.ToString();
        }
    }
}
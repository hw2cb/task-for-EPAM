using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_2
{
    internal static class StringExtensions
    {

        /// <summary>
        /// This is extension method to get the language in which the word is written
        /// </summary>
        /// <param name="str">The word you want to check </param>
        /// <returns>enum, LanguageType (Russian, English, Number, Mixed)</returns>
        public static LanguageType GetLanguage(this string str)
        {
            
            int countEnglish = 0;
            int countRussian = 0;
            int countNumber = 0;



            for(int i=0; i<str.Length; i++)
            {
                if ((str[i] >= 'а' && str[i] <= 'я') || (str[i] >= 'А' && str[i] <= 'Я') || (str[i] == 'Ё' || str[i] == 'ё'))
                    countRussian++;
                else if ((str[i] >= 'a' && str[i] <= 'z') || (str[i] >= 'A' && str[i] <= 'Z'))
                    countEnglish++;
                else if (char.IsDigit(str[i]))
                    countNumber++;
            }
            if (str.Length == countEnglish) return LanguageType.English;
            
            if(str.Length == countRussian) return LanguageType.Russian;

            if (str.Length == countNumber) return LanguageType.Number;

            else return LanguageType.Mixed;
        }
    }
}

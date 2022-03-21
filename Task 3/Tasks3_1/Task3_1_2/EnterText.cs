using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1_2
{
    internal static class EnterText
    {
        //класс отвечает за ввод и вывод текста
        private static TextAnalysis _textAnalysis;
        public static void EnterTextFromFile(int countWordInText, string pathToFile)
        {
            using(FileStream fstream = File.OpenRead(pathToFile))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string resultReadFile = System.Text.Encoding.Default.GetString(array);

                _textAnalysis = new TextAnalysis(resultReadFile, countWordInText);
            }
            
            _textAnalysis.Run();
        }
        public static void EnterTextFromConsole(int countWordInText)
        {
            string? text = Console.ReadLine();
            if (text == null) throw new ArgumentException("invalid argument, text should not be null");
            _textAnalysis = new TextAnalysis(text, countWordInText);
            _textAnalysis.Run();
        }
        public static bool CheckFile(string pathToFile)
        {
            FileInfo file = new FileInfo(pathToFile);
            if (!file.Exists)
            {
                return false;
            }
            return true;
        }
        
    }
}

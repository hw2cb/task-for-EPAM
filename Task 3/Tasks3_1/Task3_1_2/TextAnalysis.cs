using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1_2
{
    internal sealed class TextAnalysis
    {
        //слова из текста, ключ - слово, значение - количество раз встречается
        private Dictionary<string, int> _words;
        //private List<string> _text;
        private string _text;
        //поле отвечает за то, сколько раз слово должно встретиться в тексте, что бы оно считалось часто используемым
        private int _countWordInText;
        public TextAnalysis(string text, int countWordInText)
        {
            _words = new Dictionary<string, int>();
            _text = text.ToLower();
            _countWordInText = countWordInText;
        }
        public void Run()
        {
            //разделители
            char[] separators = new char[] { ',', '?', '.', ':', '!', '"', ';', ' ', '\n', '\r' };
            string [] wordsParses = _text.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);
            //создаю хеш сэт, что бы записать все слова текста без повторов
            HashSet<string> words = new HashSet<string>(wordsParses);
            //пришлось так делать, для облегчения самого метода
            words = DeletingUnneededWords(words);
            //проходим по тексту N раз = количеству всех слов текста, (слова дубли в это количество не входят)
            //можно сделать через LINQ, но я решил сделать через циклы (так как LINQ еще не было в лекциях)
            for(int i = 0; i<words.Count; i++)
            {
                for(int j = 0; j<wordsParses.Length; j++)
                {
                    if(wordsParses[j] == words.ElementAt(i))
                    {
                        if (_words.TryGetValue(wordsParses[j], out int value))
                        {
                            _words[wordsParses[j]] = value + 1;
                        }
                        else
                        {
                            _words.Add(wordsParses[j], 1);
                        }
                    }
                }
            }
            _words = _words.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            PrintResult();
        }
        private void PrintResult()
        {
            Console.WriteLine("Статистика");
            //берем отсортированый словарь, первый элемент если больше 1 (так как если все слова будут встерчаться один раз
            //то у них у всех будет значение 1

            if(_words.ElementAt(0).Value > _countWordInText)
            {
                Console.WriteLine($"Самое встречаемое слово: {_words.ElementAt(0).Key}");
            }
            else
            {
                Console.WriteLine("Автор молодец! Часто используемых слов не обнаружено");
            }
            Console.WriteLine("Если вы хотите увидеть список всех слов и солько они встречаются, нажмите Enter");
            ConsoleKey k =  Console.ReadKey(true).Key;
            if(k == ConsoleKey.Enter)
            {
                foreach(var pair in _words)
                {
                    Console.WriteLine($"Слово {pair.Key} - {pair.Value} раз");
                }
            }
        }
        private HashSet<string> DeletingUnneededWords(HashSet<string> words)
        {

            //метод удаления артиклей, предлогов
            //таких как: the, to, an, a, in, at
            // я не сильно силен в английском, пока те слова, которые пришли в голову
            //почему hashset, потому что изменяемая штука, проще удалить там слова, чем копировать массивы строк
            string[] separators = new string[] { "the", "to", "an", "a", "in", "at", "on", "of", "is", "are" };
            for(int i=0; i<words.Count; i++)
            {
                if(separators.Contains(words.ElementAt(i)))
                {
                    words.Remove(words.ElementAt(i));
                    //почему i--, потому что слово удаляется из HashSet и нужно позицию оставлять, мб костыль
                    i--;
                }
            }
            return words;
        }
    }
}

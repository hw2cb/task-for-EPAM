using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_1
{
    /* Реализовано:
     * 
     * Индексатор
     * Конкатенация
     * Substring
     * Split (по массиву разделителей)
     * Поиск символа (возвращает индекс)
     * Поиск символа (возвращает bool)
     * Метод приведения к массиву
     * Trim (обрезка пробелов)
     * Переопределен Equals
     * Операторы сравнения == / !=
     * Поиск цифр в строке
     */
    public class StringCreator
    {
        private char[] _chars;
        public int Capacity { get; private set; }
        public StringCreator()
        {
            _chars = new char[4];
            Capacity = 4;
        }
        public StringCreator(params char [] str)
        {
            _chars = new char[str.Length];
            Capacity = str.Length;
            _chars = str;
        }
        public StringCreator(int capacity)
        {
            Capacity = capacity;
            _chars = new char[capacity];
        }
        public StringCreator(StringCreator a, StringCreator b)
        {
            if (a == null || b == null) throw new ArgumentNullException();

            Capacity = a.Capacity + b.Capacity;
            _chars = AppendsChar(a, b, Capacity);
        }
        public char this[int index]
        {
            get
            {
                if(index<0 || index > Capacity) throw new ArgumentOutOfRangeException();
                return _chars[index];
            }
            set
            {
                if (index < 0 || index > Capacity) throw new ArgumentOutOfRangeException();
                _chars[index] = value;
            }
        }
        public static StringCreator operator + (StringCreator a, StringCreator b)
        {
            return new StringCreator(a, b);
        }
        public static bool operator == (StringCreator a, StringCreator b)
        {
            return a.Equals(b);
        }
        public static bool operator != (StringCreator a, StringCreator b)
        {
            return !a.Equals(b);
        }
        public char[] ToCharArray()
        {
            char[] chars = new char[Capacity];
            for (int i = 0; i < Capacity; i++)
            {
                chars[i] = _chars[i];
            }
            return chars;
        }
        public int FindCharIndex(char symbol)
        {
            /* Метод находит индекс первого вхождения символа в строке
             */
            for(int i = 0; i < Capacity; i++)
            {
                if (_chars[i] == symbol) return i;
            }
            return -1;
        }
        public bool FindChar(char symbol)
        {
            if(FindCharIndex(symbol)==-1) return false;
            return true;
        }

        public static StringCreator[] MySplit(StringCreator str, char[] separators)
        {
            //добавил метод разделения строки с сохранением разделителя
            int startIndex = 0;
            //использую хэшсет дабы защититься от попытки сунуть в метод повторяющиеся разделители
            HashSet<char> sep = new HashSet<char>(separators);
            List<StringCreator> res = new List<StringCreator>();

            for (int i = 0; i < str.Capacity; i++)
            {
                if (sep.Contains(str[i]))
                {
                    res.Add(str.Substring(startIndex, (i - startIndex) +1).Trim());
                    
                    startIndex = i + 1;
                }
            }
            //если вдруг последняя строчка без знака
            if(startIndex != str.Capacity)
            {
                res.Add(str.Substring(startIndex, (str.Capacity - startIndex)).Trim());
            }
            return res.ToArray();
        }
        public StringCreator Substring(int startIndex, int lenght)
        {
            if ((startIndex + lenght) > Capacity) throw new ArgumentOutOfRangeException();

            char[] chars = new char[lenght];
            for (int i = startIndex, j=0; j < lenght; i++, j++)
            {
                chars[j] = _chars[i];
            }
            StringCreator str = new StringCreator(chars);
            return str;
        }
        public StringCreator Trim()
        {
            //метод обрезки пробелов из начала и конца строки
            if(_chars[0] == ' ')
            {
                //обрезаю пробел в начале
                char[] newChars = _chars[1..];
                return new StringCreator(newChars);
            }
            if(_chars[_chars.Length - 1] == ' ')
            {
                //обрезаю пробел в конце
                char[] newChars = _chars[..(_chars.Length-1)];
                return new StringCreator(newChars);
            }
            if(_chars[0] == ' ' && _chars[_chars.Length - 1] == ' ')
            {
                //обрезаю и в начале и в конце
                char[] newChars = _chars[1..(_chars.Length-1)];
                return new StringCreator(newChars);
            }
            return new StringCreator(_chars);
        }
        public int[] GetDegit()
        {
            List<int> digit = new List<int>();
            for(int i=0; i<_chars.Length; i++)
            {
                if(char.IsDigit(_chars[i]))
                {
                    digit.Add(_chars[i] - '0');
                }
            }
            return digit.ToArray();
        }

        private static char[] AppendsChar(StringCreator a, StringCreator b, int capacity)
        {
            char[] buff = new char[capacity];
            int j = 0;
            for (int i = 0; i < a.Capacity; i++, j++)
            {
                buff[j] = a[i];
            }
            for (int i = 0; i < b.Capacity; i++, j++)
            {
                buff[j] = b[i];
            }
            return buff;
        }
        public override string ToString()
        {
            return new string(_chars);
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(this.GetType() != obj.GetType()) return false;

            //сравниваю поля
            //считаю что s не будет null, так как перед этим сравнивал типы
            StringCreator s = obj as StringCreator;
            if(s.Capacity != Capacity) return false;

            for(int i=0; i < Capacity; i++)
            {
                if(s[i] != _chars[i]) return false;
            }
            return true;
        }
    }
}

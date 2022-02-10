using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_1
{
    internal static class Actions
    {
        //сами методы
        public static int Multiply(int element) => element * 2;
        public static int PowTwo(int element) => element * element;

        public static int Divide(int element)
        {
            //думаю не суть важно, пусть при нуле будет возвращаться 0
            if (element == 0) return 0;
            return element / 2;
        }
    }
}

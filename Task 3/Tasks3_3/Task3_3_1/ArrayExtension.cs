using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_1
{
    internal static class ArrayExtension
    {
        //методы расширения
        public static void DoAction(this int[] array, Startup.ActionWithEveryElement function)
        {
            //метод, расширяет массив чисел, производит действия с каждым элементом. Действие передается в метод с помощью делегата
            for(int i=0; i<array.Length; i++)
            {
                //вызываю функцию
                array[i] = function.Invoke(array[i]);
            }
        }

        public static int GetSumElements(this int[] array) => array.Sum(x => x);

        public static double GetAverage(this int[] array) => array.Average();
        public static int GetFrequency(this int[] array)
        {
            var frequencyNumbers = array.GroupBy(x => x).OrderByDescending(x => x.Count()).FirstOrDefault();
            return frequencyNumbers.Key;
        }


    }
}

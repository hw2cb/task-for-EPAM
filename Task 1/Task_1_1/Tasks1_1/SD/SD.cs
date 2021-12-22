using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD
{
    public static class SD
    {
        //Static Data, статический класс для статических методов, которые повторяются
        //вынес в отдельный проект, так как уже задания начал делить по проектам
        public static int EnterNumber()
        {
            //как минимум в 3 заданиях требуется написание данного кода
            Console.WriteLine("Введите количество строк: ");
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || result <= 0)
            {
                Console.WriteLine("Введите корректное число строк: ");
            }
            return result;
        }

    }
}

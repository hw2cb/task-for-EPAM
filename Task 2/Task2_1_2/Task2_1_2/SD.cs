using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;
using Task2_1_2.Figure;

namespace Task2_1_2
{
    internal static class SD
    {
        //Static Data
        public static string UserName = "None";
        public static bool IsLogIn = false;


        private const string SELECT_ACTION_TEXT = "Выберите действие:";
        private const string ADD_FIGURE_TEXT = "1.Выберите фигуру";
        private const string OUTPUT_FIGURES_TEXT = "2.Вывести фигуры";
        private const string CLEAN_FIGURES_TEXT = "3.Очистить холст";
        private const string EXIT_TEXT = "4.Выход";
        private const string CHANGE_USER_TEXT = "5.Сменить пользователя";

        public const string SELECT_FIGURE_TEXT = "Выберите тип фигуры:";

        private const string LOG_IN_TEXT = "Введите имя пользователя:";

        public static void HeadMenuUI()
        {
            Console.WriteLine($"\n{SELECT_ACTION_TEXT}\n{ADD_FIGURE_TEXT}\n{OUTPUT_FIGURES_TEXT}\n{CLEAN_FIGURES_TEXT}\n{EXIT_TEXT}\n{CHANGE_USER_TEXT}");
        }
        public static void LogInUI()
        {
            Console.WriteLine(LOG_IN_TEXT);
        }

        public static int EnterValuePointValidation()
        {
            //метод ввода значений
            int result;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Введите число!");
            }
            return result;
        }
        public static int EnterValueValidation()
        {
            //метод ввода значений
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result <= 0))
            {
                Console.WriteLine("Число должно быть больше 0!");
            }
            return result;
        }
        public static int EnterValueMenuValidator(int border)
        {
            //метод ввода значений
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 || result >= border))
            {
                Console.WriteLine("Не корректный ввод!");
            }
            return result;
        }
    }
}

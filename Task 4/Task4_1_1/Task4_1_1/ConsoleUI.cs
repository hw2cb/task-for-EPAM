using FileManagementSystem;
using FileManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4_1_1
{
    internal class ConsoleUI
    {
        public static string ReadPath()
        {
            Console.WriteLine("Введите путь к папке, для работы: ");
            string path = Console.ReadLine();

            while(!Manager.Verify(path))
            {
                Console.WriteLine("Введите верный путь к папке");
                path = Console.ReadLine();
            }
            return path;
        }
        public static int ReadWorkMode()
        {
            Console.WriteLine("Выберите режим работы\n");
            Console.WriteLine("1. Режим отслеживания");
            Console.WriteLine("2. Режим отката изменений");
            Console.WriteLine("3. Изменить папку");

            return ReadNumber(0, 3);
        }
        public static void PrintChanges(List<Changes> changes)
        {
            foreach(var change in changes)
            {
                Console.WriteLine(change);
            }
        }
        public static void PrintDetailChanges(List<FilesChange> changes)
        {
            Console.WriteLine("Изменения в этот промежуток времени не найдены. Возможно промежуток времени слишком мал!\nСписок времени, зафиксированных изменений: ");
            foreach(var change in changes)
            {
                Console.WriteLine($"{change.StartChange} - {change.EndChange}");
            }
        }
        public static int ReadAction()
        {
            Console.WriteLine("Сохранить изменения в систему?");
            Console.WriteLine("1. Да");
            Console.WriteLine("2. Нет");
            return ReadNumber(0, 2);
        }
        public static DateTime ReadDateTime()
        {
            Console.WriteLine("Введите дату и время, на которые будет осуществлен октат. Приемлемый формат: day.month.year hour:minutes (25.02.2022 13:30)");


            DateTime dateTime;
            while(!DateTime.TryParse(Console.ReadLine(), out dateTime))
            {
                Console.WriteLine("Введите дату нужного формата!");
            }
            return dateTime;
        }
        private static int ReadNumber(int min, int max)
        {
            int result;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < 0 || result > 3))
            {
                Console.WriteLine("Введите число!");
            }
            return result;
        }
        public static void PrintNoLogs()
        {
            Console.WriteLine("Изменения в данной директории еще не зафиксированы!");
        }
        public static void PrintErrorSearch()
        {
            Console.WriteLine("");
        }
        public static void PrintSuccessRollBack(DateTime startChange, DateTime endChange)
        {
            Console.WriteLine("Откат произошел успешно!");
            Console.WriteLine($"Промежуток времени, на который вы откатились: {startChange} - {endChange}");
        }
    }
}

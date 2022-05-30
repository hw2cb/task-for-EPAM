using BLL.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PL.ConsoleUI._8_1_1
{
    internal class AwardsUI
    {
        private IAwardsBLL _manager;
        public AwardsUI(IAwardsBLL manager)
        {
            _manager = manager;
        }
        internal void CreateNewAward()
        {
            Console.Clear();
            Console.WriteLine("Название награды: ");
            string name = Console.ReadLine();
            _manager.AddAward(name);
            Console.WriteLine("Награда добавлена!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        internal void EditAwards()
        {
            Console.Clear();
            Dictionary<int, Award> awardsForDisplay = new Dictionary<int, Award>();
            Console.WriteLine("Выберите награду для редактирования: ");
            int countAward = 0;
            foreach (var award in _manager.GetAwards())
            {
                Console.WriteLine($"{countAward}.{award.Title}");
                awardsForDisplay.Add(countAward, award);
                countAward++;
            }
            int.TryParse(Console.ReadLine(), out int awardNumber);

            if (awardsForDisplay.ContainsKey(awardNumber))
            {
                Console.WriteLine("Новое название:");
                string name = Console.ReadLine();
                
                _manager.EditAward(awardsForDisplay[awardNumber].Id, name);
                Console.Clear();
                Console.WriteLine("Награда изменена!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }

        internal void RemoveAward()
        {
            Console.Clear();
            Dictionary<int, Award> awardsForDisplay = new Dictionary<int, Award>();
            Console.WriteLine("Выберите награду для удаления: ");
            int countAward = 0;
            foreach (var award in _manager.GetAwards())
            {
                Console.WriteLine($"{countAward}.{award.Title}");
                awardsForDisplay.Add(countAward, award);
                countAward++;
            }
            int.TryParse(Console.ReadLine(), out int awardNumber);

            if (awardsForDisplay.ContainsKey(awardNumber))
            {
                _manager.RemoveAward(awardsForDisplay[awardNumber].Id);
                Console.Clear();
                Console.WriteLine("Награда удалена!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }

        internal void ShowAwards()
        {
            Console.Clear();
            Console.WriteLine("Список наград:");
            foreach(var award in _manager.GetAwards())
            {
                Console.WriteLine($"{award.Title}");
            }
            Console.WriteLine("Нажмите на кнопку что бы выйти в меню");
            Console.ReadLine();
        }
    }
}

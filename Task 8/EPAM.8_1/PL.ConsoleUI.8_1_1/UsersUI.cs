using BLL;
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
    internal class UsersUI
    {
        private IUsersBLL _manager;
        private IAwardsBLL _awardsManager;
        public UsersUI(IUsersBLL manager, IAwardsBLL awardsManager)
        {
            _manager = manager;
            _awardsManager = awardsManager;
        }
        internal void CreateNewUser()
        {
            Console.Clear();
            Console.WriteLine("Ваше имя:");
            string name = Console.ReadLine();
            Console.WriteLine("Дата рождения:");
            DateTime dateOfBday = DateTime.Parse(Console.ReadLine());
            _manager.AddUser(name, dateOfBday);
            Console.Clear();
            Console.WriteLine("Пользователь добавлен!");
            Thread.Sleep(3000);
            Console.Clear();
        }

        internal void ShowUsers()
        {
            Console.Clear();
            Console.WriteLine("Список пользователей: ");
            foreach(var user in _manager.GetUsers())
            {
                Console.WriteLine(user.ToString());
            }
            Console.WriteLine("Нажмите на кнопку что бы выйти в меню");
            Console.ReadLine();
            Console.Clear();
        }

        internal void RemoveUser()
        {
            Console.Clear();
            Dictionary<int, User> usersForDisplay = new Dictionary<int, User>();
            Console.WriteLine("Выберите пользователя для удаления: ");
            int countUser = 0;
            foreach(var user in _manager.GetUsers())
            {
                Console.WriteLine($"{countUser}.{user.ToString()}");
                usersForDisplay.Add(countUser, user);
                countUser++;
            }
            int.TryParse(Console.ReadLine(), out int userNumber);
            
            if (usersForDisplay.ContainsKey(userNumber))
            {
                _manager.RemoveUser(usersForDisplay[userNumber].Id);
                Console.Clear();
                Console.WriteLine("Пользователь удален!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }

        internal void ShowUser()
        {
            Console.Clear();
            Dictionary<int, User> usersForDisplay = new Dictionary<int, User>();
            Console.WriteLine("Выберите пользователя для просмотра: ");
            int countUser = 0;
            foreach (var user in _manager.GetUsers())
            {
                Console.WriteLine($"{countUser}.{user.ToString()}");
                usersForDisplay.Add(countUser, user);
                countUser++;
            }
            int.TryParse(Console.ReadLine(), out int userNumber);

            if (usersForDisplay.ContainsKey(userNumber))
            {
                var user = _manager.GetUser(usersForDisplay[userNumber].Id);
                Console.WriteLine($"{user.ToString()}");
                Console.WriteLine("Награды пользователя: ");
                if(user.Awards == null)
                    Console.WriteLine("Наград нет");
                else
                {
                    foreach (var award in user.Awards)
                    {
                        Console.WriteLine($"{award.Title}");
                    }
                }

            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.WriteLine("Нажмите на кнопку что бы вернуться в меню");
            Console.ReadLine();
            Console.Clear();
        }

        internal void EditUser()
        {
            Console.Clear();
            Dictionary<int, User> usersForDisplay = new Dictionary<int, User>();
            Console.WriteLine("Выберите пользователя для редактирования: ");
            int countUser = 0;
            foreach (var user in _manager.GetUsers())
            {
                Console.WriteLine($"{countUser}.{user.ToString()}");
                usersForDisplay.Add(countUser, user);
                countUser++;
            }
            int.TryParse(Console.ReadLine(), out int userNumber);

            if (usersForDisplay.ContainsKey(userNumber))
            {
                Console.WriteLine("Новое имя:");
                string name = Console.ReadLine();
                Console.WriteLine("Новая дата рождения:");
                DateTime dateOfB = DateTime.Parse(Console.ReadLine());
                _manager.EditUser(usersForDisplay[userNumber].Id, name, dateOfB);
                Console.Clear();
                Console.WriteLine("Пользователь изменен!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }
        internal void AddAward()
        {
            Console.Clear();
            Dictionary<int, User> usersForDisplay = new Dictionary<int, User>();
            Dictionary<int, Award> awardsForDisplay = new Dictionary<int, Award>();
            Console.WriteLine("Выберите пользователя для награждения: ");
            int countUser = 0;
            foreach (var user in _manager.GetUsers())
            {
                Console.WriteLine($"{countUser}.{user.ToString()}");
                usersForDisplay.Add(countUser, user);
                countUser++;
            }
            

            int.TryParse(Console.ReadLine(), out int userNumber);

            Console.WriteLine("Выберите награду для пользователя: ");
            int countAward = 0;
            foreach (var award in _awardsManager.GetAwards())
            {
                Console.WriteLine($"{countAward}.{award.Title}");
                awardsForDisplay.Add(countAward, award);
                countAward++;
            }
            int.TryParse(Console.ReadLine(), out int awardNumber);
            if (awardsForDisplay.ContainsKey(awardNumber) && usersForDisplay.ContainsKey(userNumber))
            {
                
                _manager.EditUser(usersForDisplay[userNumber].Id, awardsForDisplay[awardNumber]);
                Console.Clear();
                Console.WriteLine("Пользователю назначена награда!");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Что то пошло не по плану =(");
                Thread.Sleep(3000);
            }
            Console.Clear();
        }
    }
}

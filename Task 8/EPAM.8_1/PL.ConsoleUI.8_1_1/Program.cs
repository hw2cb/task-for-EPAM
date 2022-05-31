using BLL;
using BLL.Interfaces;
using Dependencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL.ConsoleUI._8_1_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUsersBLL userBLL = DependencyResolver.Instance.UsersBLL;
            IAwardsBLL awardsBLL = DependencyResolver.Instance.AwardsBLL;

            UsersUI userUI = new UsersUI(userBLL, awardsBLL);
            AwardsUI awardsUI = new AwardsUI(awardsBLL);
            while (true)
            {
                Console.WriteLine("1.Создание нового пользователя");
                Console.WriteLine("2.Просмотр пользователей");
                Console.WriteLine("3.Удаление пользователей");
                Console.WriteLine("4.Просмотр пользователя");
                Console.WriteLine("5.Редактирование пользователя");
                Console.WriteLine("6.Создание награды");
                Console.WriteLine("7.Редактирование награды");
                Console.WriteLine("8.Удаление награды");
                Console.WriteLine("9.Просмотр всех наград");
                Console.WriteLine("10.Наградить пользователя");
                int.TryParse(Console.ReadLine(), out int result);
                switch (result)
                {
                    case 1:
                        userUI.CreateNewUser();
                        break;
                    case 2:
                        userUI.ShowUsers();
                        break;
                    case 3:
                        userUI.RemoveUser();
                        break;
                    case 4:
                        userUI.ShowUser();
                        break;
                    case 5:
                        userUI.EditUser();
                        break;
                    case 6:
                        awardsUI.CreateNewAward();
                        break;
                    case 7:
                        awardsUI.EditAwards();
                        break;
                    case 8:
                        awardsUI.RemoveAward();
                        break;
                    case 9:
                        awardsUI.ShowAwards();
                        break;
                    case 10:
                        userUI.AddAward();
                        break;
                }
            }
            
        }
    }
}

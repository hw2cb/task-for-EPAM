using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2
{
    internal sealed class GraphEditor
    {
        //список фигур, которые может использовать программа, при добавлении еще одной фигуры, в файле Program.cs
        //можно с легкостью добавить ее, не влазя в работу GraphEditor, только нужно реализовать абстрактный класс,
        //который в свою очередь требует реализовать интерфейс для фигуры

        private static Dictionary<int, GeometricFigure> _listFigureInProgramm;

        //хранилище фигур самого редактора
        //private static List<GeometricFigure> _figuresRepository;

        private static List<User> _users;
        private static User _currentUser;
        public static int CountFigures 
        {
            get { return _listFigureInProgramm.Count; }
        }
        public void Run()
        {
            while(true)
            {
                CommandHandler.EnterSelectAction();
                while (!CommandHandler.IsStart)
                {
                    Console.WriteLine("Выберите правильное действие!");
                    CommandHandler.EnterSelectAction();
                }
            }

        }
        static GraphEditor()
        {
            //при первом создании инициализирую поле со списком фигур
            _listFigureInProgramm = new Dictionary<int, GeometricFigure>();
            //_figuresRepository = new List<GeometricFigure>();
            _users = new List<User>();
        }
        public GraphEditor(List<GeometricFigure> figures)
        {
            //в обычном конструкторе заполняю статическое поле
            if (figures == null || figures.Count == 0) throw new ArgumentNullException("At least one figure is required for work");
            for(int i = 0; i < figures.Count; i++)
            {
                //добавляю в словарь, ключ - идентификатор, значение - сам объект
                _listFigureInProgramm.Add(i, figures[i]);
            }
        }


        public static void LogIn()
        {
            string name = Console.ReadLine();
            if (name == null) throw new ArgumentNullException();

            if(_users.FirstOrDefault(p =>p.Name == name) == null)
            {
                //добавление нового юзера
                User user = new User(name);
                _users.Add(user);
                _currentUser = user;
            }
            else
            {
                _currentUser = _users.FirstOrDefault(p =>p.Name == name);
            }
            
            SD.IsLogIn = true;
            SD.UserName = name;
            CommandHandler.EnterSelectAction();
        }
        public static void LogOut()
        {
            SD.IsLogIn = false;
            SD.UserName = "";
            CommandHandler.EnterSelectAction();
        }
        public static void ChangeUser()
        {
            LogOut();
        }
        public static void SelectFigure()
        {
            Console.WriteLine(SD.SELECT_FIGURE_TEXT);
            //вывод всех фигур на экран
            foreach (var figure in _listFigureInProgramm)
            {
                Console.WriteLine($"{figure.Key}.{figure.Value.Name}");
            }
            int choice = SD.EnterValueMenuValidator(_listFigureInProgramm.Count);

            
            GeometricFigure? obj = _listFigureInProgramm.GetValueOrDefault(choice);
            if (obj == null) throw new ArgumentException("its impossible to find a figure");
            
            _currentUser.Figures.Add(obj.Create());

        }
        public static void ShowFigures()
        {
            Console.WriteLine("\nСозданные фигуры: ");
            if(_currentUser.Figures.Count == 0)
            {
                Console.WriteLine("На холсте нет фигур.\n");
            }
            else
            {
                foreach(var figure in _currentUser.Figures)
                {
                    Console.WriteLine(figure);
                }
            }

        }
        public static void CleanFigures()
        {
            _currentUser.Figures.Clear();
            Console.WriteLine("Холст очищен\n");
        }


    }
}

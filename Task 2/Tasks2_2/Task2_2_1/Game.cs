using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;
using Task2_2_1.Barriers;
using Task2_2_1.Bonuses;
using Task2_2_1.Players;

namespace Task2_2_1
{
    internal class Game
    {
        private GameField _field;
        private string _playerName;
        private Player _player;
        private const int _frame = 200;
        private const float damageCactus = 15;
        private const float damageFence = 10;
        private long frequency = 5000;
        public GameStatus GameStatus { get; private set; }
        public Game(GameField field)
        {
            if (field == null) throw new ArgumentNullException("field should not be null");
            _field = field;
            GameStatus = GameStatus.NotStart;

        }
        public void Start()
        {
            //TODO: Разделить на отдельные методы
            Console.SetWindowSize(_field.Width, _field.Height);
            Console.SetBufferSize(_field.Width, _field.Height);
            Console.CursorVisible = false;


            if(GameStatus == GameStatus.NotStart)
            {
                Console.WriteLine("Введите свое имя: ");
                EnterPlayerName();
                Console.WriteLine("Выберите персонажа: ");
                SelectPlayerType();
                //CheckGameField();
                GameStatus = GameStatus.IsStart;
            }
            //приходится отрисовывать персонажа по новой, пока что костыль
            _player.Draw();
            //DrawBorder();
            DrawBarriers();
            DrawBonus();
            Direction direction = Direction.None;
            Stopwatch sw = new Stopwatch();
            while(true)
            {
                if(_player.Health <= 0)
                {
                    GameStatus = GameStatus.LosePlayer;
                    DrawLooseWindow();
                }
                if(_field.Bonuses.Count == 0)
                {
                    GameStatus = GameStatus.WinPlayer;
                    DrawWinningWindow();
                }

                //(ИСПРАВИЛ)
                //!!!в цикле приходится отрисовывать поля из за логики движения героя, это не очень хорошо, но пока я не знаю как сделать по другому 
                //(  )
                //правда худ все же пришлось оставить в цикле, так как здоровье может изменяться. В дальнейшем возможно исправлю
                //благодаря методу Clean в структуре Pixel, исправлен баг с морганием всей графики
                DrawHud();
                sw.Restart();
                while(sw.ElapsedMilliseconds <= _player.Speed)
                {
                    
                    direction = ReadKey();
                    if(direction == Direction.None)
                    {
                        //TODO: Разделить на отдельные методы
                        Console.Clear();
                        Restart();
                    }
                }
                //TODO: Прибавка к здоровью и мувспиду происходит в классе Collision, что плохо, так как этот класс не предназначен для этого
                //
                if (Collision.IsTouch(_field, _player, direction))
                    _player.Move(Direction.None);
                else if (Collision.IsTouchBonus(_field, _player, direction))
                    _player.Move(direction);
                else
                    _player.Move(direction);

            }
            
            
        }

        private void DrawWinningWindow()
        {
            Console.Clear();
            Console.WriteLine("Вы выиграли! Нажмите на кнопку что бы начать заного");
            Console.ReadKey();
            Console.Clear();
            Restart();
        }

        public void DrawLooseWindow()
        {
            Console.Clear();
            Console.WriteLine("Вы проиграли! Нажмите на кнопку что бы начать заного");
            Console.ReadKey();
            Console.Clear();
            Restart();
        }
        private void Restart()
        {
            GameStatus = GameStatus.IsStart;
            _field = new GameField(40, 30, 20, 4);
            SelectPlayerType();
            _player.Draw();
            DrawBarriers();
            DrawBonus();
        }
        public void DrawBarriers()
        {
            //метод отрисовки препятствий на карте по массиву поля
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    if(_field.Field[i, j] == 3)
                    {
                        new Cactus(damageCactus).Draw(j, i, ConsoleColor.Green);
                    }
                    if(_field.Field[i,j] == 1)
                    {
                        new Stone().Draw(j, i, ConsoleColor.Gray);
                    }
                }
            }
        }
        public void DrawBonus()
        {
            //метод отрисовки бонусов на карте по массиву поля
            for (int i = 0; i < _field.Height; i++)
            {
                for (int j = 0; j < _field.Width; j++)
                {
                    if (_field.Field[i, j] == 4)
                    {
                        new Apple(100).Draw(j, i, ConsoleColor.Yellow);
                    }
                    if (_field.Field[i, j] == 5)
                    {
                        new Cherry(50).Draw(j, i, ConsoleColor.Red);
                    }
                }
            }
        }
        public void CheckGameField()
        {
            //debug method
            _field.DEBUG_OUT();
            Console.Read();
            Console.Clear();
        }
        public void DrawHud()
        {
            //отрисовка худа, в верхнем левом углу с отступами, пожтому по иксу 2, по игрику от 1 до 3 (3 строки)
            if(_player.Health < 100)
            {
                //костыльное решение, для того что бы по новой не перерисовывать всю графику.
                //при отрисовки трехзначного здоровья рисуется 3 символа
                //как только здоровье снижается до двухзначного, рисуется 2 символа в конце, а третий остается старым, отсюда баг
                Console.SetCursorPosition(14, 1);
                Console.Write(' ');
            }
            Console.SetCursorPosition(2, 1);
            Console.Write($"Здоровье: {_player.Health}");
            Console.SetCursorPosition(2, 2);
            Console.WriteLine($"Имя игрока: {_player.Name}, персонаж: {_player.PlayerType}");
        }
        //public void DrawBarrier(int x, int y, BarrierType type)
        //{
        //    //метод отрисовки ограждения
        //    //старый метод, пока оставляю, может понадобится
        //    switch(type)
        //    {
        //        case BarrierType.Cactus:
        //            new Cactus(damageCactus).Draw(x, y, ConsoleColor.Green);
        //            break;
        //        case BarrierType.Stone:
        //            new Stone().Draw(x, y, ConsoleColor.Gray);
        //            break;
        //        case BarrierType.Fence:
        //            new Fence(damageFence).Draw(x, y, ConsoleColor.Yellow);
        //            break;
        //    }

        //}
        //public void DrawBorder()
        //{
        //    //старый метод отрисовки границ, 
        //    //метод отрисовки границы полей, границей будет кактусы
        //    for(int i=0; i < _field.Width; i++)
        //    {
        //        DrawBarrier(i, 4, BarrierType.Cactus);
        //        DrawBarrier(i, _field.Height - 1, BarrierType.Cactus);
        //    }
        //    for (int i = 4; i < _field.Height; i++)
        //    {
        //        DrawBarrier(0, i, BarrierType.Cactus);
        //        DrawBarrier(_field.Width-1, i, BarrierType.Cactus);
        //    }

        //}
        public Direction ReadKey()
        {
            Direction currentDirection = Direction.None;
            ConsoleKey key = Console.ReadKey(true).Key;
            currentDirection = key switch
            {
                ConsoleKey.UpArrow => Direction.Up,
                ConsoleKey.DownArrow => Direction.Down,
                ConsoleKey.LeftArrow => Direction.Left,
                ConsoleKey.RightArrow => Direction.Right,
                _ => Direction.None
            };
            return currentDirection;
        }
        public void EnterPlayerName()
        {
            while ((_playerName = Console.ReadLine()) == null)
            {
                Console.WriteLine("Введите имя!");
            }
            Console.Clear();
        }
        public void SelectPlayerType()
        {
            Console.WriteLine("1.Эльф\n2.Ниндзя\n3.Орк");
            int result;
            while(!int.TryParse(Console.ReadLine(), out result) || (result > 3 || result <= 0))
            {
                Console.WriteLine("\nВыберите персонажа!");
                Console.WriteLine("1.Эльф\n2.Ниндзя\n3.Орк");
            }
            switch(result)
            {
                //скорость в мелисекундах (100 - быстро, 400 - медленно)
                case 1:
                    _player = new Elf(_playerName, 200, 150);
                    break;
                case 2:
                    _player = new Ninja(_playerName, 100, 100);
                    break;
                case 3:
                    _player = new Orc(_playerName, 400, 200);
                    break;
                default:
                  
                    throw new ArgumentException("not found hero");
            }
            Console.Clear();
        }

    }
    enum GameStatus
    {
        IsStart,
        NotStart,
        None,
        WinPlayer,
        LosePlayer
    }
    enum BarrierType
    {
        None,
        Stone,
        Cactus,
        Fence
    }
}

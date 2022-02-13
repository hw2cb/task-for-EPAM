using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class Player
    {
        public float Speed { get; private set; }
        public float Health { get; private set; }
        public string Name { get; private set; }
        public abstract string PlayerType { get; }
        public int currentX { get; private set; } = 1;
        public int currentY { get; private set; } = 4;
        public Pixel DisplayHero { get; private set; }
        public char DisplayChar { get; }
        public Player(string name, float speed, float health, char display)
        {
            if (speed < 0) throw new ArgumentException("speed should be > 0");
            if (health < 0) throw new ArgumentException("health should be > 0");
            Name = name;
            Speed = speed;
            Health = health;
            DisplayChar = display;
            currentX = 2;
            currentY = 5;
            DisplayHero = new Pixel(currentX, currentY, ConsoleColor.Red, DisplayChar);
            DisplayHero.Draw();
        }
        public void Draw()
        {
            //метод отрисовки персонажа
            //если необходимо отрисовать принудительно
            DisplayHero.Draw();
        }
        public void Move(Direction direction)
        {
            /* Геймплей
             * 1) Урон при касании с границей
             * 2) Урон при касании с ограждениями наносящие урон
             * 3) Не возможно пройти через ограждения
             * 
             */


            //чистим старую отрисовку
            DisplayHero.Clean();
            //меняем координаты
            switch(direction)
            {
                case Direction.Left:
                    currentX--;
                    break;
                case Direction.Right:
                    currentX++;
                    break;
                case Direction.Up:
                    currentY--;
                    break;
                case Direction.Down:
                    currentY++;
                    break;
                case Direction.None:
                    break;
            }
            //рисуем новую
            //да,можно было обойтись одной структурой, но по совету Рихтера, структура должна оставать не изменяемой, поэтому создаю новую
            //если это не верно, могу исправить
            DisplayHero = new Pixel(currentX, currentY, ConsoleColor.Red, DisplayChar);
            
            DisplayHero.Draw();

        }
        public void DoDamage(float damage)
        {
            if (Health < 0) Health = 0;
            Health = Health - damage;
        }
        public void SetHealth(float health)
        {
            if (Health < 0) Health = 0;
            Health = Health + health;
        }
        public void SetSpeed(float speed)
        {
            //минимальная скорость у каждого героя - 10, меньше опускаться не может
            if (Speed < 10) Speed = 10;
            // минус, потому что в моей реализации, чем меньше значение скорости, тем быстрее двигается герой
            Speed = Speed - speed;
        }
        
    }
}

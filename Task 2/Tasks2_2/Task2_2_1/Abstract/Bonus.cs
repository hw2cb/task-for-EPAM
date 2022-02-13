using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class Bonus
    {
        //баф (какое то число, либо скорость либо здоровье
        public float Buff { get; private set; }
        //частота появления
        public int Frequency { get; private set; }
        public char Display { get; private set; }
        public Bonus(float buff, int frequency, char display)
        {
            if (buff < 0) throw new ArgumentException("buff should be > 0");
            if (frequency < 0) throw new ArgumentException("frequency should be > 0");
            Buff = buff;
            Display = display;
        }
        public void Draw(int x, int y, ConsoleColor color)
        {
            Pixel bonus = new Pixel(x, y, color, Display);
            bonus.Draw();
        }
    }
}

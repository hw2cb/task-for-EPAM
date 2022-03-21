using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class Barrier
    {
        public int Frequency { get; private set; }
        public char Display { get; private set; }
        public Barrier(int frequency, char display)
        {
            if (frequency < 0) throw new ArgumentException("frequency should be > 0");
            Frequency = frequency;
            Display = display;
        }
        public void Draw(int x, int y, ConsoleColor color)
        {
            Pixel barrier = new Pixel(x, y, color, Display);
            barrier.Draw();
        }
    }
}

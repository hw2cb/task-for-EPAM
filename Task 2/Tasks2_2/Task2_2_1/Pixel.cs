using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1
{
    internal struct Pixel
    {
        //пиксель для отрисовки
        public int PositionX { get; private set; }
        public int PositionY { get; private set; }
        public char Symbol { get; private set; }
        public ConsoleColor Color { get; set; }
        public Pixel(int positionX, int positionY, ConsoleColor color, char symbol)
        {
            PositionX = positionX;
            PositionY = positionY;
            Color = color;
            Symbol = symbol;
        }
        public void Draw()
        {
            Console.ForegroundColor = Color;
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(Symbol);
            Console.ResetColor();
        }
        public void Clean()
        {
            Console.SetCursorPosition(PositionX, PositionY);
            Console.Write(' ');

        }
    }
}

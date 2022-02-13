using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Square : SquareFigure
    {
        public Square(){}
        public Square(Point center, double sideA) : base(center, sideA)
        {
        }

        public double Area => SideA * SideA;

        public double Length => SideA * 4;

        public override string Name => "Квадрат";

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point center;
            double sideA = 0;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты начальной точки: ");
            center.X = SD.EnterValuePointValidation();
            center.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите длину стороны: ");
            sideA = SD.EnterValueValidation();
            return new Square(center, sideA);
        }

        public override string ToString()
        {
            return $"Square with coordinats ({Center.X}:{Center.Y}), side: {SideA}, perimeter: {Length}, area: {Area}";
        }

    }
}

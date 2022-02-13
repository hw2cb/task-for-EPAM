using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Circle : RoundFigure
    {
        public double Length => 2 * Math.PI * Radius;
  
        public double Area => Math.PI * Radius * Radius;
        public override string Name => "Окружность";

        public Circle(){}
        public Circle(Point center, double radius) : base(center, radius) { }

        public override string ToString()
        {
            return $"Circle with center coordinats ({Center.X}:{Center.Y}), radius {Radius}, area {Area} and length {Length}";
        }

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point center;
            double radius = 0;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты центра круга: ");
            center.X = SD.EnterValuePointValidation();
            center.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите радиус круга: ");
            radius = SD.EnterValueValidation();
            return new Circle(center, radius);

        }
    }
}

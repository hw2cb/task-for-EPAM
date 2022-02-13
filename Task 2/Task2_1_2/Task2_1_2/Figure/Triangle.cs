using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Triangle : GeometricFigure
    {
        private Line firstLine;
        private Line secondLine;
        private Line thirdLine;

        public double Length => firstLine.Length + secondLine.Length + thirdLine.Length;

        //полупериметр для формулы герона
        private double HalfPerimeter => Length / 2;

        //формула Герона
        //Квадратный корень из Полупериметр*(Полупериметр-А)*(Полупериметр-B)*(Полупериметр-С)
        public double Area => Math.Sqrt(HalfPerimeter * (HalfPerimeter - firstLine.Length) * (HalfPerimeter - secondLine.Length) * (HalfPerimeter - thirdLine.Length));

        public override string Name => "Треугольник";
        public Triangle(){}
        public Triangle (Point firstPoint, Point secondPoint, Point thirdPoint):base(firstPoint)
        {
            //в базовый коструктор передаю начинающую точку
            //треугольник имеет три линии
            firstLine = new Line(firstPoint, secondPoint);
            secondLine = new Line(secondPoint, thirdPoint);
            thirdLine = new Line(thirdPoint, firstPoint);            
        }

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point first;
            Point second;
            Point third;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты первой точки: ");
            first.X = SD.EnterValuePointValidation();
            first.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите координаты второй точки: ");
            second.X = SD.EnterValuePointValidation();
            second.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите координаты третьей точки: ");
            third.X = SD.EnterValuePointValidation();
            third.Y = SD.EnterValuePointValidation();
            return new Triangle(first, second, third);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Rectangle : SquareFigure
    {
        private double sideB;
        public double SideB 
        { 
            get { return sideB; }
            set 
            {
                if (value <= 0) throw new ArgumentException("Side should be >0");
                sideB = value; 
            }  
        }
        public Rectangle(){}
        public Rectangle(Point center, double sideA, double sideB) : base(center, sideA)
        {
            SideB = sideB;
        }

        public double Area => SideA*SideB;

        public double Length => (SideA*2)+(SideB*2);

        public override string Name => "Прямоугольник";

        public override string ToString()
        {
            return $"Rectangle with coordinats ({Center.X}:{Center.Y}), side A: {SideA}, side B: {SideB}, perimeter: {Length}, area: {Area}";
        }

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point center;
            double sideA = 0;
            double sideB = 0;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты начальной точки: ");
            center.X = SD.EnterValuePointValidation();
            center.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите длину первой стороны: ");
            sideA = SD.EnterValueValidation();
            Console.WriteLine($"Введите длину второй стороны: ");
            sideB = SD.EnterValueValidation();
            return new Rectangle(center, sideA, sideB);
        }
    }
}

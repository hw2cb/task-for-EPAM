using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Ring : RoundFigure
    {
        //в задании сказано о внутреннем круге и внешнем, поэтому использую два круга
        private Circle _outerCircle;
        private Circle _innerCircle;
        public double Area { get; }
        public double Length { get; }

        public override string Name => "Кольцо";
        public Ring(){}

        //решил что радиус у кольца будет считать его внутренний радиус
        public Ring(Point center, double innerRadius, double outerRadius):base(center, innerRadius)
        {
            _outerCircle = new Circle(center, outerRadius);
            _innerCircle = new Circle(center, innerRadius);

            Area = _outerCircle.Area - _innerCircle.Area;
            Length = _outerCircle.Length + _outerCircle.Length;
        }
        public override string ToString()
        {
            return $"Ring with center coordinats ({Center.X}:{Center.Y}) outer radius {_outerCircle.Radius}, inner radius {_innerCircle.Radius}";
        }

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point center;
            double innerRadius = 0;
            double outerRadius = 0;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты начальной точки: ");
            center.X = SD.EnterValuePointValidation();
            center.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите внутренний радиус: ");
            innerRadius = SD.EnterValueValidation();
            Console.WriteLine($"Введите внешний радиус: ");
            outerRadius = SD.EnterValueValidation();
            return new Ring(center, innerRadius, outerRadius);
        }
    }
}

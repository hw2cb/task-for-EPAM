using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2.Figure
{
    internal class Line : GeometricFigure
    {
        //в данном случае, считаю что родитель будет хранить начальную точку (как центр у круга)
        private Point _end;
        public Point End 
        { 
            get { return _end; }
            set
            {
                //здесь Center - свойство родителя, хранящий точку. У линии буду считать что хранит начало линии, у окружностей - центр.
                //переопределить Equals
                if (value.Equals(Center)) throw new ArgumentException("Start and End points of the line should be different");
                _end = value;
            }
        }
        public double Length => Math.Sqrt(Math.Pow((_end.X - Center.X), 2) + Math.Pow((_end.Y - Center.Y), 2));
        public override string Name => "Линия";

        public Line(){}
        public Line(Point start, Point end) : base(start)
        {
            End = end;
        }
        public override string ToString()
        {
            return $"Line with start ({Center.X}:{Center.Y}), end ({_end.X}:{_end.Y}), length: {Length}";
        }

        public override GeometricFigure Create()
        {
            //метод создания фигуры для графического редактора
            //родительский класс реализует интерфейс GraphEditorable, который обязует реализовывать данный метод и требует переопределять его во
            //всех классах, которые мы хотим использовать в программе, мысль такая.
            Point first;
            Point second;
            Console.WriteLine($"Введите параметры фигуры {Name}");
            Console.WriteLine($"Введите координаты начальной точки {Name}: ");
            first.X = SD.EnterValuePointValidation();
            first.Y = SD.EnterValuePointValidation();
            Console.WriteLine($"Введите координаты конечной точки {Name}: ");
            second.X = SD.EnterValuePointValidation();
            second.Y = SD.EnterValuePointValidation();
            return new Line(first, second);
        }
    }
}

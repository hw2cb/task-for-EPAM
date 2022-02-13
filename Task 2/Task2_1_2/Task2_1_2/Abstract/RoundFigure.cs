using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2.Abstract
{
    internal abstract class RoundFigure : GeometricFigure
    {
        private double radius;
        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value <= 0) throw new ArgumentException("Radius should be > 0");
                radius = value;
            }
        }
        protected RoundFigure(){}
        protected RoundFigure(Point center, double radius):base(center)
        {
            Radius = radius;
        }
    }
}

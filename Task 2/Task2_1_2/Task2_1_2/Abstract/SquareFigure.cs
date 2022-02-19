using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_1_2.Abstract
{
    internal abstract class SquareFigure : GeometricFigure
    {
        private double sideA;
        public double SideA 
        { 
            get { return sideA; }
            set
            {
                if (value <= 0) throw new ArgumentException("Side should be >0");
                sideA = value;
            }
        }
        public SquareFigure(){}
        protected SquareFigure(Point center, double sideA) : base(center)
        {
            SideA = sideA;
        }
    }
}

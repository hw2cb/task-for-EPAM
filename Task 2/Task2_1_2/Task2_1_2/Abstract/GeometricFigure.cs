using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Interface;

namespace Task2_1_2.Abstract
{
    internal abstract class GeometricFigure : GraphEditorable
    {
        public Point Center { get; private set; }
        public abstract string Name { get; }
        public GeometricFigure(){}
        public GeometricFigure(Point center)
        {
            Center = center;
        }

        public abstract GeometricFigure Create();
    }
}

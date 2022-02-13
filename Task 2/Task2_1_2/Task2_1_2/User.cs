using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2
{
    internal class User
    {
        public string Name { get; }
        public List<GeometricFigure> Figures { get; }
        public User(string name)
        {
            Name = name;
            Figures = new List<GeometricFigure>();
        }
    }
}

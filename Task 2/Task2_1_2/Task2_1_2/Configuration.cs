using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_1_2.Abstract;

namespace Task2_1_2
{
    internal class Configuration
    {
        public static GraphEditor AddFigures(params GeometricFigure[] figures)
        {
            // создаю класс, прокидываю через конструктор указанные в конфигурационном классе фигуры 
            return new GraphEditor(figures.ToList());
        }

    }
}

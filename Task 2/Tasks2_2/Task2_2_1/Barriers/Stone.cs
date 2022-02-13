using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Barrier = Task2_2_1.Abstract.Barrier;

namespace Task2_2_1.Barriers
{
    internal class Stone : Barrier
    {
        //препятствие без урона будет появлять с частотой 6
        public Stone() : base(6, 'O')
        {

        }
    }
}

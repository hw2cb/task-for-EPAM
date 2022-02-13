using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;

namespace Task2_2_1.Bonuses
{
    internal class Apple : BonusSpeed
    {

        public Apple(float buff): base(buff, (char)26)
        {

        }
    }
}

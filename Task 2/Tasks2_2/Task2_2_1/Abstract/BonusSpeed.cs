using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class BonusSpeed : Bonus
    {
        //все бонусы на скорость будут появляться с частотой 10
        public BonusSpeed(float buff, char display):base(buff, 10, display)
        {

        }
    }
}

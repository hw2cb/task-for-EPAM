using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class BonusHealth : Bonus
    {
        //все бонусы на здоровье будут появляться с частотой 5
        public BonusHealth(float buff, char display):base(buff, 5, display)
        {

        }

    }
}

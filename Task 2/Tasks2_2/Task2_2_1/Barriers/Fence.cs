using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;

namespace Task2_2_1.Barriers
{
    internal class Fence : BarrierDamage
    {
        public Fence(float damage) : base(damage, '#')
        {

        }
    }
}

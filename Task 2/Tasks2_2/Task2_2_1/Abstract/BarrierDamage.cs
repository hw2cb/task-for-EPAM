using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    internal class BarrierDamage : Barrier
    {
        public static float Damage { get; private set; }
        //препятсивия наносящие урон появляются с частотой 4
        public BarrierDamage(float damage, char display):base(4, display)
        {
            if (damage < 0) throw new ArgumentException("damage should be > 0");
            Damage = damage;
        }
    }
}

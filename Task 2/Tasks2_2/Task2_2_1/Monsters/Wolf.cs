using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;

namespace Task2_2_1.Monsters
{
    internal class Wolf : Monster
    {
        public Wolf(float health, float damage, Bonus loot) : base(health, damage, loot)
        {
                
        }
    }
}

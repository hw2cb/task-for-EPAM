using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_2_1.Abstract
{
    abstract class Monster
    {
        public float Health { get; private set; }
        public float Damage { get; private set; }
        
        public Bonus Loot{ get; private set; }

        public Monster(float health, float damage, Bonus loot)
        {
            if (health < 0) throw new ArgumentException("health should be > 0");
            if (damage < 0) throw new ArgumentException("damage should be > 0");
            if (loot == null) throw new ArgumentNullException("Loot should not be null");
            Health = health;
            Damage = damage;
            Loot = loot;
        }
    }
}

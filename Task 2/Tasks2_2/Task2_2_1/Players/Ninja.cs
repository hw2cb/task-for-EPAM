using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;

namespace Task2_2_1.Players
{
    internal class Ninja : Player
    {
        public override string PlayerType { get; }
        public Ninja(string name, float speed, float health): base(name, speed, health, (char)1)  
        {
            PlayerType = "Ниндзя";
        }
    }
}

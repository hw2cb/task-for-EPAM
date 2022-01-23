﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_2_1.Abstract;

namespace Task2_2_1.Players
{
    internal class Orc : Player
    {
        public override string PlayerType { get; }
        public Orc(string name, float speed, float health): base(name, speed, health, (char)2)   
        {
            PlayerType = "Орк";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_1_1
{
    internal class Human
    {
        public string Name { get; private set; }
        public Human(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Human with name {Name}";
        }
    }
}

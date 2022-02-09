using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki
{
    internal sealed class Enter
    {
        //Входы
        private float _weight;
        public float Weight { get; private set; }
        public Enter(float weight)
        {
            _weight = weight;
        }
    }
}

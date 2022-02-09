using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neironki
{
    internal sealed class Neuron
    {
        //n количество входов
        //сумму входов (по весам)
        //
        /*
         * метод, GetActivation:
         * если сумма  меньше значения порогового то -1
         * 
         * 
         */
        public Enter[] Enters { get; set; }
        public float Alpha { get; set; }
        public float Gamma { get; set; }
        public Neuron(float alpha, float gamma, params Enter [] enters)
        {
            if (enters == null) throw new ArgumentNullException();

            Enters = enters;
            Alpha = alpha;
            Gamma = gamma;
        }
        public float Sum()
        {
            float res = 0f;
            foreach(var item in Enters)
            {
                res += item.Weight;
            }
            return res;
        }
        public int GetActivation(int sum)
        {
            //1/1+exp^-a(sum+a)  +B
            return 1/1+Math.Exp;
        }

    }
}

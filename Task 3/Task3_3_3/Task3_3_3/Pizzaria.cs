using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_3
{
    internal class Pizzaria
    {
        //класс, который только делает пиццы, не знает ни о чем
        //событие, когда приготовление окончено
        public event Action<int> EndCoock;
        public void StartCoock(int orderNumber)
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            EndCoock(orderNumber);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_3
{
    internal class Order
    {
        //модель заказа 
        //объект не отправляется в пиццерию, отправляется только номер заказа!
        public int OrderNumber { get; private set; }
        public User User { get; private set; }
        public Order(int orderNumber, User user)
        {
            OrderNumber = orderNumber;
            User = user;
        }
    }
}

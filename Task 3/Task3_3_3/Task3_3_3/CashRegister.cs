using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3_3_3
{
    internal class CashRegister
    {
        //класс, некая сущности кассы, которая регистрирует заказ и передает пиццерии команду, начать делать пиццы
        //так же, класс отвечает за то, что бы оповестить клиента о готовности его пиццы
        private Pizzaria _pizzaria;
        public Queue<Order> Orders { get; private set; }
        //событие, которое отвечает за уведомление пользователя
        public event Action<string> Notification;
        public CashRegister(Pizzaria pizzaria)
        {
            _pizzaria = pizzaria;
            Orders = new Queue<Order>();
        }

        public void AcceptOrder(string nameUser)
        {
            User user = new User(nameUser);
            Order order;
            if (Orders.Count == 0)
                order = new Order(1, user);
            else
                order = new Order(Orders.Last().OrderNumber + 1, user);

            Orders.Enqueue(order);
            if (Orders.Count > 0)
            {
                _pizzaria.EndCoock += OrderComplete;
                _pizzaria.StartCoock(order.OrderNumber);
            }
                
        }

        private void OrderComplete(int orderNumber)
        {
            Order order = Orders.FirstOrDefault(x => x.OrderNumber == orderNumber);
            if(order != null)
            {
                Notification(order.User.Name);
                Orders.Dequeue();
            }
        }

    }
}

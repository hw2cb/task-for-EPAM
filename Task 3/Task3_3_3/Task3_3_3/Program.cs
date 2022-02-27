

namespace Task3_3_3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Pizzaria pizzaria = new Pizzaria();
            CashRegister cashRegister = new CashRegister(pizzaria);
            while(true)
            {
                Console.WriteLine("Нажмите Y, что бы сделать заказ");
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Y)
                {
                    Console.Clear();
                    DoOrder(cashRegister);
                }

                else
                    break;
            }



        }
        private static void DoOrder(CashRegister cashRegister)
        {
            Console.WriteLine("Для заказа, введите имя: ");
            string name = Console.ReadLine();


            Console.WriteLine("Ваш заказ отправлен в пиццерию! Ожидайте уведомления");
            cashRegister.Notification += Notify;
            cashRegister.AcceptOrder(name);
            cashRegister.Notification -= Notify;
        }
        private static void Notify(string name)
        {
            Console.WriteLine($"{name}, ваш заказ готов!");
        }
    }
}
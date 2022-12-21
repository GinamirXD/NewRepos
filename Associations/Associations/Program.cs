namespace Associations
{
    internal class Program
    {
        static void Main()
        {
            MyShop shop = new MyShop();
            shop.Init();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine();
                Console.WriteLine("Выберите пункт меню:");
                Console.WriteLine("1. Просмотреть товары.");
                Console.WriteLine("2. Просмотреть покупателей");
                Console.WriteLine("3. Просмотреть заказы");
                Console.WriteLine("4. Ввести заказ");
                Console.WriteLine("5. Выйти");

                var k = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (k)
                {
                    case 1:
                        {
                            shop.PrintItems();
                            break;
                        }
                    case 2:
                        {
                            shop.PrintCustomers();
                            break;
                        }
                    case 3:
                        {
                            shop.PrintOrders();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Введите номер покупаетеля");
                            shop.PrintCustomers();
                            var cId = int.Parse(Console.ReadLine());
                            if (!shop.ExistCustomer(cId))
                                break;

                            Console.WriteLine("Введите номер товара");
                            shop.PrintItems();
                            var pId = int.Parse(Console.ReadLine());
                            if (!shop.ExistItem(pId))
                                break;

                            Console.WriteLine("Введите номер заказа");
                            var number = int.Parse(Console.ReadLine());

                            Console.WriteLine("Введите адрес");
                            string address = Console.ReadLine();

                            Console.WriteLine("Экспресс доставка");
                            Console.WriteLine("1.Да");
                            Console.WriteLine("2.Нет");

                            bool expressDelivery = true;
                            var i = int.Parse(Console.ReadLine());
                            switch (i)
                            {
                                case 1:
                                    {
                                        expressDelivery = true;
                                        break;
                                    }
                                case 2:
                                    {
                                        expressDelivery = false;
                                        break;
                                    }
                            }

                            Console.WriteLine("Введите количество");
                            var quantity = int.Parse(Console.ReadLine());


                            shop.AddNewOrder(cId, pId, address, number, expressDelivery, quantity);
                            break;
                        }
                    case 5:
                        {
                            exit = true;
                            break;
                        }
                    default:
                        break;
                }
            }
        }
    }
}
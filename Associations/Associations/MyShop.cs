using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    public class MyShop
    {
        public List<Item> Items { get; set; } = new List<Item>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<OrderLine> Orders { get; set; } = new List<OrderLine>();

        public void Init()
        {

            Items.Add(new Item() 
            {
                Article = 1,
                Name = "Ноутбук",
                Price = 3000
            });
            Items.Add(new Item()
            {
                Article = 2,
                Name = "Смартфон",
                Price = 1000
            });
            Items.Add(new Item()
            {
                Article = 3,
                Name = "Телевизор",
                Price = 5000
            });
            Items.Add(new Item()
            {
                Article = 4,
                Name = "Пылесос",
                Price = 1200
            });
            Customers.Add(new Customer()
            {
                Code = 1,
                ContactPhone = 1234,
                FullName = "Иванов Иван Иванович",
                Privileged = true
            });
            Customers.Add(new Customer()
            {
                Code = 2,
                ContactPhone = 7382,
                FullName = "Петров Сергей Алексеевич",
                Privileged = false
            });

        }
        public bool ExistItem(int id)
        {
            foreach (var p in Items)
            {
                if (p.Article == id)
                    return true;
            }
            return false;
        }
        public bool ExistCustomer(int id)
        {
            foreach (var c in Customers)
            {
                if (c.Code == id)
                    return true;
            }
            return false;
        }
        public void PrintItems()
        {
            Console.WriteLine("Список товаров;");

            foreach (var item in Items)
            {
                Console.WriteLine(item);
            }
        }
        public void PrintCustomers()
        {
            Console.WriteLine("Список заказчиков;");
            foreach (var cust in Customers)
            {
                Console.WriteLine(cust);
            }
        }
        public void PrintOrders()
        {
            Console.WriteLine("Список заказов;");
            foreach (var ord in Orders)
            {
                Console.WriteLine(ord);
                Console.WriteLine(GetOrderPrice(ord));
            }
        }
        public void AddNewOrder(int code, int article, string address, int number, bool expressDelivery, int quantity)
        {
            Customer customer = null;
            foreach (var c in Customers)
            {
                if (c.Code == code)
                    customer = c;
            }
            Item item = null;
            foreach (var i in Items)
            {
                if (i.Article == article)
                    item = i;
            }
            var ord = new Order(customer, number, address, expressDelivery);
            var ordLine = new OrderLine(item, quantity, ord);

            Orders.Add(ordLine);
            Console.WriteLine("Добавлен заказ:");
            Console.WriteLine(ordLine);
        }

        public double GetOrderPrice(OrderLine orderLine)
        {
            double orderPrice = orderLine.Item.Price * orderLine.Quantity;
            if (orderLine.Order.ExpressDelivery)
                orderPrice += 0.25 * orderPrice;
            if (orderLine.Order.Customer.Privileged && orderPrice > 1500)
                orderPrice -= 0.15 * orderPrice;
            return orderPrice;
        }
    }
}

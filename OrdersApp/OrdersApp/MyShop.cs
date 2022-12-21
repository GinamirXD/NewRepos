using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersApp
{
    internal class MyShop
    {
        public List<Product> Products { get; set; } = new List<Product>();
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Order> Orders { get;set; } = new List<Order>();

        public void Init()
        {
            Orders.Clear();
            Products.Add(new Product()
            {
                ProductId = 1,
                Name = "Apples",
                Price = 100,
                Count = 1000
            });
        }
        public void PrintProducts()
        {

        }
    }
}

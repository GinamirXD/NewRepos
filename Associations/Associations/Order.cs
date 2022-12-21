    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Associations
{
    public class Order
    {
        public int Number { get; set; }
        public DateTime CreationDate { get; set; }
        public string Address { get; set; }
        public bool ExpressDelivery { get; set; }
        public Customer Customer { get; set; }

        public Order(Customer cust, int number, string address, bool expressDelivery)
        {
            Customer = cust;
            Number = number;
            CreationDate = DateTime.Now; ;
            Address = address;
            ExpressDelivery = expressDelivery;
        }

        public override string ToString()
        {
            return $"Заказ {Number} - {CreationDate} {Customer} {Address} Экспрес доставка:{ExpressDelivery}";
        }
    }
}

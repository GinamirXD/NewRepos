using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Associations
{
    public class OrderLine
    {
        public int Quantity { get; set; }
        public Item Item { get; set; }
        public Order Order { get; set; }

        public OrderLine(Item item, int quantity, Order order)
        {
            Quantity = quantity;
            Order = order;
            Item = item;
        }

        public override string ToString()
        {
            return $"Заказ {Order} {Item} {Quantity}";
        }
    }
}

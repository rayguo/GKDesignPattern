using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
    public class OrderDecorator : Order
    {
        private Order wrappedOrder = null;

        public OrderDecorator(Order order)
        {
            wrappedOrder = order;
        }

        public override void AddItem(string productCode, int quantity, decimal cost, decimal weight)
        {
            wrappedOrder.AddItem(productCode, quantity, cost, weight);
        }

        public override IEnumerable<OrderItem> Items
        {
            get { return wrappedOrder.Items;  }
        }

        public override void PrintOrderItems()
        {
            wrappedOrder.PrintOrderItems();
        }

        public override decimal TotalCost
        {
            get { return wrappedOrder.TotalCost; }
        }
    }
}

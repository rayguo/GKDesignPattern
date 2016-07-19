using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
    public class SimpleOrder : Order
    {
        List<OrderItem> items = new List<OrderItem>();

        public override void AddItem(string productCode, int quantity, decimal cost , decimal weight)
        {
            items.Add(new OrderItem(productCode, quantity, cost, weight));
        }

        public override  void PrintOrderItems()
        {
            foreach (OrderItem item in items)
            {
                Console.WriteLine("{0} x {1} @ {2} = {3:C}", item.ProductCode, item.Quantity, item.UnitCost, item.Cost);
            }
            Console.WriteLine();
            Console.WriteLine("Sub Total {0:C}" , TotalCost);
            Console.WriteLine();
        }


        public override IEnumerable<OrderItem> Items { get { return items; } }

        public override decimal TotalCost
        {
            get
            {
                decimal total = 0;

                foreach(OrderItem item in items )
                {
                    total += item.Cost;
                }

                return total;
            }
        }
    }
}

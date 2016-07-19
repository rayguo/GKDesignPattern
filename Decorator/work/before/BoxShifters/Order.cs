using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
   public struct OrderItem
    {
        private string productCode;
        private int quantity;
        private decimal unitCost;
        private decimal unitWeight;

        public OrderItem(string productCode , int quantity , decimal unitCost , decimal unitWeight)
        {
            this.productCode = productCode;
            this.quantity = quantity;
            this.unitCost = unitCost;
            this.unitWeight = unitWeight;
        }

        public string ProductCode { get { return productCode; } }
        public int Quantity { get { return quantity; } }
        public decimal UnitCost { get { return unitCost; } }
        public decimal Cost { get { return unitCost * quantity; } }

        public decimal UnitWeight { get { return unitWeight; } }
        public decimal Weight { get { return unitWeight * quantity; } }

        
    }

    public class Order
    {
        List<OrderItem> items = new List<OrderItem>();

        public Order()
        {

        }

        public void AddItem(string productCode, int quantity, decimal cost , decimal weight)
        {
            items.Add(new OrderItem(productCode, quantity, cost, weight));
        }

        public IEnumerable<OrderItem> Items { get { return items; } }


        public  void PrintOrderItems()
        {
            foreach (OrderItem item in items)
            {
                Console.WriteLine("{0} x {1} @ {2} = {3:C}", item.ProductCode, item.Quantity, item.UnitCost, item.Cost);
            }
            Console.WriteLine();
            Console.WriteLine("Sub Total {0:C}", TotalCost);
            Console.WriteLine();
        }


        public decimal TotalCost
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

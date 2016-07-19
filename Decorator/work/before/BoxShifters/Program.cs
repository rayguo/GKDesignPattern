using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
    // Express Delivery
    // Credit Card Sur charge
    // Gift Wrapped
    // International Delivery

    class Program
    {
        static void Main(string[] args)
        {

            Order order = new Order();

            order.AddItem("P-X", 2, 1.5M, 0.2M);
            order.AddItem("P-ABC", 1, 3.0M, 0.5M);
            order.AddItem("P-Z", 5, 1.9M, 0.1M);
            order.AddItem("P-Foo", 1, 8.0M, 1.5M);
            order.AddItem("P-Useless", 1, 5.6M, 0.6M);
            order.AddItem("P-CBA", 2, 2.3M, 0.4M);
            
            //
            // Customise the order
            // 
            

            PrintOrderConfirmation(order);
        }

        private static void PrintOrderConfirmation(Order order)
        {
            order.PrintOrderItems();

            Console.WriteLine("Grand Total bill {0:C}", order.TotalCost);
        }
    }
}

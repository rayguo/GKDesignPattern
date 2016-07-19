using System;
using System.Collections.Generic;
using System.Text;

namespace BoxShifters
{
    public class ExpressDeliveryOrder : OrderDecorator
    {
        private const decimal DeliveryCharge = 4.0M;

        private Order wrappedOrder;

        public ExpressDeliveryOrder(Order order) : base(order)
        {
            wrappedOrder = order;
        }

        public override void PrintOrderItems()
        {
            base.PrintOrderItems();

            Console.WriteLine("Express delivery charge of {0:C}" , DeliveryCharge);
        }

        public override decimal TotalCost
        {
            get
            {
                return base.TotalCost + DeliveryCharge;
            }
        }
    }
}

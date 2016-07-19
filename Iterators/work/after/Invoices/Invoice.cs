using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices
{
    public class Invoice
    {
        private Order order;

        public Order Order
        {
            get { return order; }
            private set { order = value; }
        }

        public Invoice()
        {
        }

        Predicate<IItem> SingleItems = delegate(IItem iitem)
        {
            LineItem line = iitem as LineItem;
            if (line == null || line.Count == 1)
                return true;
            else
                return false;
        };

        public IEnumerable<IItem> GetItems()
        {
            foreach (IItem item in Order.GetItems(SingleItems))
            {
                yield return item;
            }
        }

        public void LoadInvoice()
        {
            order = new Order();
            order.LoadOrders();
        }
    }
}

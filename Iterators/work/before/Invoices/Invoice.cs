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

        public IEnumerable<LineItem> GetItems()
        {
            return order.GetItems();
        }

        public void LoadInvoice()
        {
            order = new Order();
            order.LoadOrders();
        }
    }
}

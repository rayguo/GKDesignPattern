using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public class LineItem : IItem
    {
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private double unitPrice;

        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        public void Accept(IItemVisitor visitor)
        {
            visitor.VisitLineItem(this);
        }
    }
}

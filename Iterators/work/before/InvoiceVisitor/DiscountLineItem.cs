using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public class DiscountLineItem : IItem
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

        private char discountReason;

        public char DiscountReason
        {
            get { return discountReason; }
            set { discountReason = value; }
        }

        private double discountAmount;

        public double DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public class RefundLineItem:IItem
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

        private double refundAmount;

        public double RefundAmount
        {
            get { return refundAmount; }
            set { refundAmount = value; }
        }

        private string refundReason;

        public string RefundReason
        {
            get { return refundReason; }
            set { refundReason = value; }
        }


    }
}

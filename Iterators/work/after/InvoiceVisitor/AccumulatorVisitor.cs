using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public class AccumulatorVisitor:IItemVisitor
    {
        private double amount;

        public double Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public void VisitLineItem(LineItem lineItem)
        {
            amount += lineItem.UnitPrice * lineItem.Count;
        }

        public void VisitRefundLineItem(RefundLineItem refundLineItem)
        {
            amount -= refundLineItem.RefundAmount;
        }

        public void VisitDiscountLineItem(DiscountLineItem discountLineItem)
        {
            amount += discountLineItem.Count * discountLineItem.UnitPrice;
            amount -= discountLineItem.Count * discountLineItem.DiscountAmount;
        }
    }
}

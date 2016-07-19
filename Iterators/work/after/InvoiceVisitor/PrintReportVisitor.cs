using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public class PrintReportVisitor : IItemVisitor
    {
        public void VisitLineItem(LineItem lineItem)
        {
            Console.WriteLine("{0} {1} at {2:C}: Total Price {3:C}",
                lineItem.Count, lineItem.Description, lineItem.UnitPrice, (lineItem.Count * lineItem.UnitPrice));
        }

        public void VisitRefundLineItem(RefundLineItem refundLineItem)
        {
            Console.WriteLine("{0} {1} refunded, Total Refund Price {2:C}", 
                refundLineItem.Count, refundLineItem.Description, refundLineItem.RefundAmount);
        }

        public void VisitDiscountLineItem(DiscountLineItem discountLineItem)
        {
            double originalCost = discountLineItem.Count * discountLineItem.UnitPrice;
            double discountAmount = discountLineItem.DiscountAmount * discountLineItem.Count;
            double newCost = originalCost - discountAmount;

            Console.WriteLine("{0} {1} at {2:C}: Original Price {3:C}. Discount Amount: {4:C} for {5} Reason",
                discountLineItem.Count, discountLineItem.Description, discountLineItem.UnitPrice,
                originalCost, discountAmount,
                discountLineItem.DiscountReason);
        }
    }
}

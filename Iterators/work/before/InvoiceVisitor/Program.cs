using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice();

            invoice.LoadInvoice();

            PrintReport(invoice);

            Console.WriteLine("---------------------------------------");

            double total = GetTotalPayable(invoice);

            Console.WriteLine("Total cost is: {0:C}", total);


        }

        private static double GetTotalPayable(Invoice invoice)
        {
            RefundLineItem refundLineItem;
            DiscountLineItem discountLineItem;
            LineItem lineItem;

            double amount = 0;

            foreach (IItem item in invoice.LineItems)
            {
                if ((lineItem = item as LineItem) != null)
                {
                    // for the line item the price is per price
                    amount += (lineItem.UnitPrice * lineItem.Count);
                }
                else if ((discountLineItem = item as DiscountLineItem) != null)
                {
                    // for the Discount the discount is per unit
                    amount += (discountLineItem.Count * discountLineItem.UnitPrice);
                    amount -= (discountLineItem.Count * discountLineItem.DiscountAmount);
                }
                else
                {
                    // for the refund, the refund is the total
                    refundLineItem = item as RefundLineItem;
                    amount -= refundLineItem.RefundAmount;
                }
            }
            return amount;
        }

        private static void PrintReport(Invoice invoice)
        {
            RefundLineItem refundLineItem;
            DiscountLineItem discountLineItem;
            LineItem lineItem;

            foreach (IItem item in invoice.LineItems)
            {
                if ((lineItem = item as LineItem) != null)
                {
                    Console.WriteLine("{0} {1} at {2:C}: Total Price {3:C}", 
                        lineItem.Count, lineItem.Description, lineItem.UnitPrice, (lineItem.Count * lineItem.UnitPrice));
                }
                else if ((discountLineItem = item as DiscountLineItem) != null)
                {
                    double originalCost = discountLineItem.Count * discountLineItem.UnitPrice;
                    double discountAmount = discountLineItem.DiscountAmount * discountLineItem.Count;
                    double newCost = originalCost - discountAmount;

                    Console.WriteLine("{0} {1} at {2:C}: Original Price {3:C}. Discount Amount: {4:C} for {5} Reason", 
                        discountLineItem.Count, discountLineItem.Description, discountLineItem.UnitPrice, 
                        originalCost, discountAmount,
                        discountLineItem.DiscountReason);
                }
                else
                {
                    refundLineItem = item as RefundLineItem;
                    Console.WriteLine("{0} {1} refunded, Total Refund Price {2:C}",
                        refundLineItem.Count, refundLineItem.Description, refundLineItem.RefundAmount);
                }
            }
        }
    }
}

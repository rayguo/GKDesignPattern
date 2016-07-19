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

            //foreach (IItem item in invoice.LineItems)
            //{
            //    Console.WriteLine("{0} {1} @ {2}", item.Count, item.Description, item.UnitPrice);
            //}

            PrintReport(invoice);

            Console.WriteLine("---------------------------------------");

            double total = GetTotalPayable(invoice);

            Console.WriteLine("Total cost is: {0:C}", total);

        }

        private static double GetTotalPayable(Invoice invoice)
        {
            AccumulatorVisitor visitor = new AccumulatorVisitor();

            foreach (IItem item in invoice.LineItems)
            {
                item.Accept(visitor);
            }
            return visitor.Amount;
        }

        private static void PrintReport(Invoice invoice)
        {
            PrintReportVisitor visitor = new PrintReportVisitor();

            foreach (IItem item in invoice.LineItems)
            {
                item.Accept(visitor);
            }
        }
    }
}

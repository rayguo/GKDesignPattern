using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices
{
    class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice();
            invoice.LoadInvoice();
        }
    }
}

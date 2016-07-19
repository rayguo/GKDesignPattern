using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceVisitor
{
    public interface IItem
    {
        int Count { get; set; }
        string Description { get; set; }
        double UnitPrice { get; set; }
    }
}

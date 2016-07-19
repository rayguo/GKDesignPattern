using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices
{
    public interface IItem
    {
        IEnumerable<IItem> GetItems(Predicate<IItem> filter);
        int Count { get; }
        string Description { get; }
        double UnitPrice { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Invoices
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

        public override string ToString()
        {
            return string.Format("{0} {1}(s) @ {2:C}", Count, Description, UnitPrice);
        }

        #region IItem Members

        public IEnumerable<IItem> GetItems(Predicate<IItem> filter)
        {
            if (filter == null || filter(this))
                yield return this;
            else
                yield break;
        }

        #endregion
    }
}

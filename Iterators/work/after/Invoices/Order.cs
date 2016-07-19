using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Invoices
{
    public class Order : IItem
    {
        List<IItem> lineItems = new List<IItem>();

        const string LINE_ITEM_IDENTIFIER = "L";
        const string ORDER_START_IDENTIFIER = "OS";
        const string ORDER_END_IDENTIFIER = "OE";

        private List<IItem> LineItems
        {
            get { return lineItems; }
        }

        private string title = "Base Order";

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public IEnumerable<IItem> GetItems(Predicate<IItem> filter)
        {
            // yield ourselves
            // this will cause the code to print the title of the order
            if (filter == null || filter(this))
            {
                yield return this;
            }

            // iterate over each item 
            foreach (IItem item in LineItems)
            {
                // for each item, iterate over the children
                // this will either be another order or a LineItem
                // If item is an Order then GetItems calls back into
                // this method which iterates over the child items 
                // collection
                // If item is a LineItem then GetItems for LineItem yield returns
                // a single value and that value is yield returned from here
                foreach (IItem childItem in item.GetItems(filter))
                {
                    if (filter == null || filter(childItem))
                    {
                        yield return childItem;
                    }
                }
            }
        }


        public void LoadOrders()
        {
            using (StreamReader reader = new StreamReader(@"..\..\invoices.csv"))
            {
                string lineRead;
                while ((lineRead = reader.ReadLine()) != null)
                {
                    ProcessLine(reader, lineRead);
                }
            }
        }

        private void ProcessLine(StreamReader reader, string lineRead)
        {
            string[] lineItemSplit = lineRead.Split(new char[] { ',' });
            if (lineItemSplit[0] == LINE_ITEM_IDENTIFIER)
            {
                ProcessLineItem(lineItemSplit);
            }
            else if (lineItemSplit[0] == ORDER_START_IDENTIFIER)
            {
                ProcessOrder(reader, lineItemSplit[1]);
            }
        }

        private void ProcessOrder(StreamReader reader, string title)
        {
            Order order = new Order();
            order.Title = title;
            string lineRead;
            while ((lineRead = reader.ReadLine()) != null)
            {
                string[] lineItemSplit = lineRead.Split(new char[] { ',' });
                if (lineItemSplit[0] == ORDER_END_IDENTIFIER)
                    break;

                order.ProcessLine(reader, lineRead);
            }
            LineItems.Add(order);
        }

        private void ProcessLineItem(string[] parsedLine)
        {
            LineItem li = new LineItem();
            li.Count = int.Parse(parsedLine[1]);
            li.Description = parsedLine[2];
            li.UnitPrice = double.Parse(parsedLine[3]);
            LineItems.Add(li);
        }

        public override string ToString()
        {
            return this.Title;
        }

        #region IItem Members

        public int Count
        {
            get { return 0; }
        }

        public string Description
        {
            get { return ""; }
        }

        public double UnitPrice
        {
            get { return 0.0; }
        }

        #endregion
    }
}

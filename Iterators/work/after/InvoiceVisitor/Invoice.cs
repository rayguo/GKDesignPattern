using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace InvoiceVisitor
{
    public class Invoice
    {
        const string LINE_ITEM_IDENTIFIER = "L";
        const string DISCOUNT_ITEM_IDENTIFIER = "D";
        const string REFUND_ITEM_IDENTIFIER = "R";

        private List<IItem> lineItems = new List<IItem>();

        public List<IItem> LineItems
        {
            get { return lineItems; }
            set { lineItems = value; }
        }


        public Invoice()
        {
        }

        public void LoadInvoice()
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
            else if (lineItemSplit[0] == DISCOUNT_ITEM_IDENTIFIER)
            {
                ProcessDiscountLineItem(lineItemSplit);
            }
            else if (lineItemSplit[0] == REFUND_ITEM_IDENTIFIER)
            {
                ProcessRefundLineItem(lineItemSplit);
            }
        }

        private void ProcessLineItem(string[] parsedLine)
        {
            LineItem li = new LineItem();
            li.Count = int.Parse(parsedLine[1]);
            li.Description = parsedLine[2];
            li.UnitPrice = double.Parse(parsedLine[3]);
            LineItems.Add(li);
        }

        private void ProcessDiscountLineItem(string[] parsedLine)
        {
            DiscountLineItem dli = new DiscountLineItem();
            dli.Count = int.Parse(parsedLine[1]);
            dli.Description = parsedLine[2];
            dli.UnitPrice = double.Parse(parsedLine[3]);
            string reason = parsedLine[4].Trim();
            dli.DiscountReason = reason[0];
            dli.DiscountAmount = double.Parse(parsedLine[5]);
            LineItems.Add(dli);
        }

        private void ProcessRefundLineItem(string[] parsedLine)
        {
            RefundLineItem rli = new RefundLineItem();
            rli.Count = int.Parse(parsedLine[1]);
            rli.Description = parsedLine[2];
            rli.UnitPrice = double.Parse(parsedLine[3]);
            rli.RefundReason = parsedLine[4];
            rli.RefundAmount = double.Parse(parsedLine[5]);
            LineItems.Add(rli);
        }
    }
}

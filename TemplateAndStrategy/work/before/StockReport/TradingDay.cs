using System;
using System.Collections.Generic;
using System.Text;

namespace StockReport
{
    public class TradingDay
    {
        public TradingDay(string csvRow)
        {

            string[] vals = csvRow.Split(',');
            Date = DateTime.Parse(vals[0]);
            Open = double.Parse(vals[1]);
            High = double.Parse(vals[2]);
            Low = double.Parse(vals[3]);
            Close = double.Parse(vals[4]);
            Volume = double.Parse(vals[5]);

            // Fix for two digit days..Assuming that any
            // future date is actually previous centruary data
            if (Date> DateTime.Now)
            {
                Date = Date.AddYears(-100);
            }
        }

        public override string ToString()
        {
            return String.Format("{0},{1},{2},{3},{4},{5}", Date.ToShortDateString() , Open, High, Low, Close, Volume);
        }

        private DateTime date;

        public DateTime Date
        {
            get { return date; }
            private set { date = value; }
        }
        private double open;

        public double Open
        {
            get { return open; }
            set { open = value; }
        }
        private double high;

        public double High
        {
            get { return high; }
            private set { high = value; }
        }
        private double low;

        public double Low
        {
            get { return low; }
            private set { low = value; }
        }
        private double close;

        public double Close
        {
            get { return close; }
            private set { close = value; }
        }
        private double volume;

        public double Volume
        {
            get { return volume; }
            private set { volume = value; }
        }

    }
}

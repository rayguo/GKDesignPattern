using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace StockReport
{
    class StockMarket
    {
        List<TradingDay> tradingDays = new List<TradingDay>();

        public StockMarket(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                // Skip header row
                reader.ReadLine();
                string dataRow = null;

                while ((dataRow = reader.ReadLine()) != null)
                {
                    tradingDays.Add(new TradingDay(dataRow));
                }
            }
        }

        /// <summary>
        /// Returns an iterator to iterate through each trading day
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TradingDay> GetTradingDays()
        {
            return tradingDays;
        }
    }
}

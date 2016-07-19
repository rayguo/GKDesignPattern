using System;
using System.Collections.Generic;
using System.Text;

namespace StockReport
{
    class Program
    {
        static void Main(string[] args)
        {
            StockMarket tradingDays = new StockMarket(@"..\..\stockData.csv");
            
            //PrintHighDailySwings(tradingDays);    

            // Reports days with large swing.
            ReportTradingDays(tradingDays , IsHighDailySwing);

            // Reports days with high volume
            ReportTradingDays(tradingDays, delegate(TradingDay day) { return day.Volume > 20000000; });

        }

        private static void ReportTradingDays(StockMarket tradingDays , Predicate<TradingDay> filter)
        {
            foreach (TradingDay day in tradingDays.GetTradingDays())
            {
                if (filter(day) )
                {
                    Console.WriteLine(day.ToString());
                }
            }
        }

        private static bool IsHighVolumeDay(TradingDay day)
        {
            return (day.Volume > 20000000);
        }

        private static bool IsHighDailySwing(TradingDay day)
        {
            double swing = day.Open - day.Close;

            double percentageSwing = Math.Abs(swing / day.Open);

            return (percentageSwing > 0.1);
        }
    }
}

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

            PrintHighDailySwings(tradingDays);    
        }
 
        private static void PrintHighDailySwings(StockMarket tradingDays)
        {
            foreach (TradingDay day in tradingDays.GetTradingDays())
            {
                if (StrategyTemplate.ReportOnTradingDay(day))
                {
                    Console.WriteLine(day.ToString());
                }  
            }
        }
    }
}

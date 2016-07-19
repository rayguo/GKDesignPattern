using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockReport
{
    class StrategyTemplate
    {


        public static bool ReportOnTradingDay(TradingDay day)
        {
            double swing = day.Open - day.Close;

            double percentageSwing = Math.Abs(swing / day.Open);

            if (percentageSwing > 0.1)
            {
                return true;
            }
            return false;
        }

        protected abstract double 
    }
}

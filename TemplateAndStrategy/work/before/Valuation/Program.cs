using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Valuation
{
    
    class Program
    {
        static void Main(string[] args)
        {

            ClassicAccount classic = new ClassicAccount();
            TaxFreeAccount taxFree = new TaxFreeAccount();
            VariableAccount variable = new VariableAccount();

            PrintAccountForecasts(classic, taxFree, variable);
        }

        public static void PrintAccountForecasts(params AccountTemplate[] accounts)
        {
            foreach (AccountTemplate account in accounts)
            {
                account.Deposit(5000);

                for (int nYear = 1; nYear <= 10; nYear++)
                {
                    Console.Write(nYear);
                    account.PayYearlyInterest();
                    Console.WriteLine(",{0:C}", account.Balance);  
                }
            }

            /*for (int nYear = 1; nYear <= 10; nYear++)
            {

                Console.Write(nYear);
                foreach (AccountTemplate account in accounts)
                {
                    account.PayYearlyInterest();
                    Console.WriteLine(",{0:C}" , account.Balance );
                }
            }*/
        }
    }
}

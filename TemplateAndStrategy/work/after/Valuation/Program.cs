using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount savings = new VariableInterestAccount();

            ProduceTable(new ClassicAccount(), new TaxFreeSavings(), new VariableInterestAccount());
          
        }

        public static void ProduceTable(params BankAccount[] accounts)
        {
            foreach (BankAccount account in accounts)
            {
                account.Deposit(5000);
            }

            for (int nYear = 1; nYear <= 10; nYear++)
            {
                Console.Write(nYear);
                foreach (BankAccount account in accounts)
                {
                    account.PayYearlyInterest();
                    Console.Write(",{0:C}" ,account.Balance);
                }
                Console.WriteLine();
            }

        }
    }
}

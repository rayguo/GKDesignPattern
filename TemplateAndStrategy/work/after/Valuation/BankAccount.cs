using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    public abstract class BankAccount
    {
        private decimal balance;

        public void Deposit(decimal value)
        {
            this.balance += value;
        }

        public void PayYearlyInterest()
        {
            decimal grossInterestPayment = balance * InterestRate;

            decimal netInterestPayment = grossInterestPayment - grossInterestPayment * TaxRate;

            balance += netInterestPayment;

        }

        public decimal Balance
        {
            get { return balance; }
        }


        protected abstract decimal InterestRate { get; }
        protected abstract decimal TaxRate { get; }
    }

}

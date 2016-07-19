using System;
using System.Collections.Generic;
using System.Text;

namespace Valuation
{
    public abstract class AccountTemplate
    {
        private decimal _balance;

        public void PayYearlyInterest()
        {
            decimal grossInterestPayment = _balance * Interestrate;

            decimal netInterestPayment = grossInterestPayment - grossInterestPayment * Taxrate;

            _balance += netInterestPayment;

        }

        public void Deposit(decimal value)
        {
            this._balance += value;
        }

        public decimal Balance
        {
            get { return _balance; }
        }

        protected abstract decimal Interestrate { get; }

        protected abstract decimal Taxrate { get; }
    }

}

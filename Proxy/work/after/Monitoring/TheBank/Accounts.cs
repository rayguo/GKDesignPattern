using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TheBank
{
    public class Account : MarshalByRefObject
    {
        private decimal balance;
        private object accountLock = new object();
        private int accountNumber;

        internal Account(int accountNumber)
        {
            this.accountNumber = accountNumber;
        }

        public int AccountNumber
        {
            get { return accountNumber; }
        }

        public decimal Balance { get { return balance; } }

        public void Credit(decimal amount)
        {
            lock (accountLock)
            {
                balance += amount;
            }

        }

        public void Debit(decimal amount)
        {
            lock (accountLock)
            {
                balance -= amount;
            }
        }
        
    }
}

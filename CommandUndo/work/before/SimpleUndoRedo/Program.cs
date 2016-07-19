using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleUndoRedo
{
    public class BankAccount
    {
        decimal balance;

        public decimal Balance { get { return balance; } }

        public void Credit(decimal amount)
        {
            balance += amount;
        }

        public void Debit(decimal amount)
        {
            balance -= amount;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            account.Credit(10);
            Console.WriteLine("Balance is {0:C}" , account.Balance);


        }
    }
}

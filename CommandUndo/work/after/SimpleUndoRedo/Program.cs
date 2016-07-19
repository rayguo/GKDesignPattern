using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern;

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
            UndoRedoInvoker invoker = new UndoRedoInvoker();
            BankAccount account = new BankAccount();

            // account.Credit(10);

            invoker.Execute(new CreditCommand(account, 10));
            invoker.Execute(new CreditCommand(account, 10));
            invoker.Execute(new CreditCommand(account, 10));

            Console.WriteLine("Balance is {0:C}" , account.Balance);

            while (invoker.HasCommandsToUndo)
            {
                invoker.UndoLastCommand();

                Console.WriteLine("Balance is {0:C}", account.Balance);
            }

            while (invoker.HasCommandsToRedo)
            {
                invoker.RedoLastUndo();

                Console.WriteLine("Balance is {0:C}", account.Balance);
            } 

        }
    }
}

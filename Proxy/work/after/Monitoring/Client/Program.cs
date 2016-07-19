using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using Monitoring;
using TheBank;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ExerciseTheBank();    
        }

        public delegate void AccountAction(Account account);

        public static void ExerciseTheBank()
        {
            Random rnd = new Random();
            Bank bank = Bank.GetInstance();

            List<AccountAction> actions = new List<AccountAction>();

            // Possible operations to perform on an Account
            actions.Add(delegate(Account account) { account.Debit(rnd.Next(1000)); Console.Write("-"); });
            actions.Add(delegate(Account account) { account.Credit(rnd.Next(1000)); Console.Write("+"); });
            actions.Add(delegate(Account account) { decimal balance = account.Balance; Console.Write("=");  });

            int numberOfActions = actions.Count;
            int maxDelayBetweenTransaction = 500;

            while (true)
            {
                int accountNumber = rnd.Next(bank.MaxAccountNumber);
                Account account = bank.GetAccount(accountNumber);

                actions[rnd.Next(numberOfActions)](account);
                Thread.Sleep(rnd.Next(maxDelayBetweenTransaction));

                if (Console.KeyAvailable)
                {
                    // Simulate run on bank
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.R:
                            {
                                numberOfActions = 1;
                                maxDelayBetweenTransaction = 10;
                            }
                            break;

                        case ConsoleKey.C:
                            {
                                numberOfActions = actions.Count;
                                maxDelayBetweenTransaction = 500;
                            }
                            break;
                    }
                }
            }
        }
    }
}

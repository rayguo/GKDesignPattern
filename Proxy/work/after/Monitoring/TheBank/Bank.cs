using System;
using System.Collections.Generic;
using System.Text;
using Monitoring;

namespace TheBank
{
    public class Bank
    {
        private static object _initLock = new object();

        private static Bank _instance;

        public static Bank GetInstance()
        {
            if (_instance == null)
            {
                CreateInstance();
            }
            return _instance;
        }

        private static void CreateInstance()
        {
            lock (_initLock)
            {
                if (_instance == null)
                {
                    _instance = new Bank();
                }
            }
        }

        private Account[] accounts;

        private const int NUMBER_OF_ACCOUNTS = 10000;

        private Bank()
        {
            accounts = new Account[NUMBER_OF_ACCOUNTS];

            for (int nAccount = 0; nAccount < NUMBER_OF_ACCOUNTS; nAccount++)
            {
                accounts[nAccount] = new Account(nAccount);
            }
        }

        public int MaxAccountNumber
        {
            get { return NUMBER_OF_ACCOUNTS - 1; }
        }

        public Account GetAccount(int accountNumber)
        {
            Account account = (Account) new MethodCounterProxy(accounts[accountNumber]).GetTransparentProxy();

            return account;
        }
    }

}

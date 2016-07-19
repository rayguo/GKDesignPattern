using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    partial class BankAccount
    {
        private class ClosingState : BankAccountState
        {
            public ClosingState(BankAccount account)
                : base(account)
            {

            }

            public override string ToString()
            {
                return "Closing";
            }

            public override void EnterState()
            {
                if (account.Balance == 0)
                {
                    account.State = account.closedAccountState;
                }
            }

            public override void Debit(decimal amount)
            {
                if (amount > account.Balance)
                {
                    throw new InvalidOperationException("Can't go overdrawn");
                }

                account.Balance -= amount;

                if (account.Balance == 0)
                {
                    account.State = account.closedAccountState;
                }
            }
        }
    }
}

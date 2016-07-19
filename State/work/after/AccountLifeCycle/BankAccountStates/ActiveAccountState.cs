using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    partial class BankAccount
    {
        private class ActiveAccountState : BankAccountState
        {
            public ActiveAccountState(BankAccount account)
                : base(account)
            {
            }

            public override string ToString()
            {
                return "Active";
            }

            public override void Debit(decimal amount)
            {
                account.Balance -= amount;
            }

            public override void Credit(decimal amount)
            {
                account.Balance += amount;
            }

            public override void Freeze()
            {
                account.State = account.frozenAccountState;
            }

            public override void Close()
            {
                account.State = account.closingAccountState;
            }
        }
    }
}

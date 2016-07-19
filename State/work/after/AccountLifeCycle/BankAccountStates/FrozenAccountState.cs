using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    partial class BankAccount
    {
        private class FrozenAccountState : BankAccountState
        {
            public FrozenAccountState(BankAccount account)
                : base(account)
            {

            }

            public override string ToString()
            {
                return "Frozen";
            }

            public override void UnFreeze()
            {
                account.State = account.activeAccountState;
            }
        }
    }
}

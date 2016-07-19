using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    partial class BankAccount
    {
        private class ClosedState : BankAccountState
        {
            public  ClosedState(BankAccount account)
                : base(account)
            {

            }

            public override string ToString()
            {
                return "Closed";
            }
        }
    }
}

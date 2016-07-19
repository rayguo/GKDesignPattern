using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    public partial class BankAccount
    {
        private class IdentifyingCustomerState : BankAccountState
        {
            public IdentifyingCustomerState(BankAccount account) : base(account)
            {

            }

            public override string ToString()
            {
                return "Identifying Customer";
            }

            public override void IdentityConfirmed()
            {
                // Move to new State
                account.State = account.activeAccountState;
            }
        }
    }
}

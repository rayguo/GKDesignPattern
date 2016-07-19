using System;
using System.Collections.Generic;
using System.Text;

namespace AccountLifeCycle
{
    public abstract class BankAccountState
    {
        protected BankAccount account;

        protected BankAccountState(BankAccount account)
        {
            this.account = account;
        }

        public virtual void EnterState()
        {
            // Called on entry to the state
        }

        public virtual void LeaveState()
        {
            // Called on leaving the state
        }

        public virtual void IdentityConfirmed()
        {
            throw new InvalidOperationException("Account does not support IdentityConfirmation in current state");
        }

        public virtual void Credit(decimal amount)
        {
            throw new InvalidOperationException("Account does not support Credit in current state");
        }

        public virtual void Debit(decimal amount)
        {
            throw new InvalidOperationException("Account does not support Debit in current state");
        }

        public virtual void Freeze()
        {
            throw new InvalidOperationException("Account does not support Freeze in current state");
        }

        public virtual void UnFreeze()
        {
            throw new InvalidOperationException("Account does not support UnFreeze in current state");
        }

        public virtual void Close()
        {
            throw new InvalidOperationException("Account does not support Close in current state");

        }

    }
}

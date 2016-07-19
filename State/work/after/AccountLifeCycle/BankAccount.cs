using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AccountLifeCycle
{
    public partial class BankAccount : INotifyPropertyChanged
    {
        private BankAccountState identifyingCustomerState;
        private BankAccountState activeAccountState;
        private BankAccountState frozenAccountState;
        private BankAccountState closingAccountState;
        private BankAccountState closedAccountState;


        private BankAccountState accountState;
        
        public BankAccount()
        {
            identifyingCustomerState = new IdentifyingCustomerState(this);
            activeAccountState = new ActiveAccountState(this);
            frozenAccountState = new FrozenAccountState(this);
            closingAccountState = new ClosingState(this);
            closedAccountState = new ClosedState(this);

            accountState = identifyingCustomerState;

        }

        public BankAccountState State
        {
            get { return accountState; }
            private set
            {
                if (accountState != null)
                {
                    accountState.LeaveState();
                }

                accountState = value;
                OnPropertyChanged(new PropertyChangedEventArgs("State")); 
                accountState.EnterState();  }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; OnPropertyChanged(new PropertyChangedEventArgs("Balance")); }

        }


        public void IdentityConfirmed()
        {
            accountState.IdentityConfirmed();
        }

        public void Credit(decimal amount)
        {
            accountState.Credit(amount);
        }

        public void Debit(decimal amount)
        {
            accountState.Debit(amount);
        }

        public void Freeze()
        {
            accountState.Freeze();
        }

        public void UnFreeze()
        {
            accountState.UnFreeze();
        }

        public void Close()
        {
            accountState.Close();
        }


        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, args);
            }

        }
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}

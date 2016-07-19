using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace AccountLifeCycle
{
    public class BankAccount : INotifyPropertyChanged
    {
        public enum AccountStates
        {
            CONFIRMING_IDENTITY,
            ACTIVE,
            FROZEN,
            CLOSING,
            CLOSED
        };


        private AccountStates accountState;
        
        public BankAccount()
        {
            State = AccountStates.CONFIRMING_IDENTITY;
        }

        public AccountStates State
        {
            get { return accountState; }
            private set { accountState = value; OnPropertyChanged(new PropertyChangedEventArgs("State")); }
        }

        private decimal balance;
        public decimal Balance
        {
            get { return balance; }
            private set { balance = value; OnPropertyChanged(new PropertyChangedEventArgs("Balance")); }

        }


        public void IdentityConfirmed()
        {
            if (State != AccountStates.CONFIRMING_IDENTITY)
            {
                throw new InvalidOperationException("Account does not support IdentityConfirmation in current state");
            }

            State = AccountStates.ACTIVE;
        }

        public void Credit(decimal amount)
        {
            if (State != AccountStates.ACTIVE)
            {
                throw new InvalidOperationException("Account does not support Credit in current state");
            }

            Balance += amount;
        }

        public void Debit(decimal amount)
        {
            if ((State != AccountStates.ACTIVE) && ( State != AccountStates.CLOSING) )
            {
                throw new InvalidOperationException("Account does not support Debit in current state");
            }

            if ( State == AccountStates.CLOSING )
            {
                if (amount > Balance)
                {
                    throw new InvalidOperationException("You can't go overdrawn now");
                }
            }

            Balance -= amount;

            if ((State == AccountStates.CLOSING) && (Balance == 0))
            {
                State = AccountStates.CLOSED;
            }
        }

        public void Freeze()
        {
            if (State != AccountStates.ACTIVE)
            {
                throw new InvalidOperationException("Account does not support Freeze in current state");
            }

            State = AccountStates.FROZEN;
        }

        public void UnFreeze()
        {
            if ( State != AccountStates.FROZEN )
            {
                throw new InvalidOperationException("Account does not support UnFreeze in current state");
            }

            State = AccountStates.ACTIVE;
        }

        public void Close()
        {
            if ((accountState == AccountStates.ACTIVE) ||
                (accountState == AccountStates.CONFIRMING_IDENTITY))
            {
                State = AccountStates.CLOSING;
            }
            else
            {
                throw new InvalidOperationException("Account does not support Close in current state");
            }
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

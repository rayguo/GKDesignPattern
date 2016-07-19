using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern;

namespace SimpleUndoRedo
{
    public class CreditCommand : Command
    {
        private BankAccount target;
        private decimal amount;

        public CreditCommand(BankAccount account , decimal amount)
        {
            target = account;
            this.amount = amount;
        }
        public override void Execute()
        {
            target.Credit(amount);
        }

        public override void Undo()
        {
            target.Debit(amount);
        }
    }

    public class DebitCommand : Command
    {
        private BankAccount target;
        private decimal amount;

        public DebitCommand(BankAccount account, decimal amount)
        {
            target = account;
            this.amount = amount;
        }
        public override void Execute()
        {
            target.Debit(amount);
        }

        public override void Undo()
        {
            target.Credit(amount);
        }
    }
}

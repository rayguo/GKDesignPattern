using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AccountLifeCycle
{
    public partial class BankAccountForm : Form
    {
        private BankAccount account = new BankAccount();
      
        public BankAccountForm()
        {
            InitializeComponent();

            balanceLabel.DataBindings.Add(new Binding("Text", account, "Balance"));
            statusLabel.DataBindings.Add(new Binding("Text", account, "State"));
        

        }


        private void debitButton_Click(object sender, EventArgs e)
        {
            decimal value = 0;

            decimal.TryParse(amountTextbox.Text, out value);

            account.Debit(value);
        }

        private void creditButton_Click(object sender, EventArgs e)
        {
            decimal value = 0;

            decimal.TryParse(amountTextbox.Text, out value);

            account.Credit(value);
        }

        private void ConfirmIdentity(object sender, EventArgs e)
        {
            account.IdentityConfirmed();
        }

        private void freezeButton_Click(object sender, EventArgs e)
        {
            account.Freeze();
        }

        private void unfreezeButton_Click(object sender, EventArgs e)
        {
            account.UnFreeze();
        }

        private void closeAccount_Click(object sender, EventArgs e)
        {
            account.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ShowWorkflow(object sender, EventArgs e)
        {
            new AccountWorkflowForm().Show();
        }



    }
}
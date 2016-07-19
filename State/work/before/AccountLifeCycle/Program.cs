using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AccountLifeCycle
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {

            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            BankAccountForm bankAccountForm = new BankAccountForm();

            bankAccountForm.Show();

            Application.Run(bankAccountForm);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception.GetType() == typeof(InvalidOperationException))
            {
                MessageBox.Show("You can't do that..", "Illegal Account Operation", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                throw e.Exception;
            }
        }
    }
}

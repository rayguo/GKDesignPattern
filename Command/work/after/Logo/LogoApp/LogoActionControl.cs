using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace LogoApp
{
    

    public partial class LogoActionControl : UserControl
    {
        public event EventHandler<RepeatActionEventArgs> DoAction;

        public LogoActionControl()
        {
            InitializeComponent();

            button1.Click += delegate(object sender , EventArgs e) { OnDoAction(new RepeatActionEventArgs( Iterations)); };
        }

        public string ActionName
        {
            get { return button1.Text; }
            set { button1.Text = value; }
        }

        public int Iterations
        {
            get { return (int) numericUpDown1.Value; }
        }


        protected virtual void OnDoAction(RepeatActionEventArgs e)
        {
            if (DoAction != null)
            {
                DoAction(this,e);
            }
        }

    }

    public class RepeatActionEventArgs : EventArgs
    {
        internal RepeatActionEventArgs(int nTimes)
        {
            this.nTimes = nTimes;
        }

        private int nTimes;

        public int NTimes
        {
            get { return nTimes; }
        }
    }
}

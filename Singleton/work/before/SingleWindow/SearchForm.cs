using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SingleWindow
{
    public partial class SearchForm : Form
    {
        private static readonly object SharedLock = new object();
        private static SearchForm _searchForm;

        public SearchForm()
        {
            InitializeComponent();
            Console.WriteLine(@"Created a single search form");
        }

        public static SearchForm GetInstance()
        {
            if (_searchForm == null)
            {
                lock (SharedLock)
                {
                    if (_searchForm == null)
                        _searchForm = new SearchForm();
                }
            }
            return _searchForm;
        }


        private void findButton_Click(object sender, EventArgs e)
        {
            // Would typically do the actual find operation
            // but in this case just hide 
            this.Hide();
        }

        private void CloseForm(object sender, EventArgs e)
        {
            this.Hide();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
            base.OnClosing(e);
        }
    }
}
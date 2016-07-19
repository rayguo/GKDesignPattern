using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SingleWindow
{
    public partial class SexyNotepadForm : Form
    {
        public SexyNotepadForm()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SexyNotepadForm().Show();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (UtilityForms.findForm == null)
            {
                UtilityForms.findForm = SearchForm.GetInstance();
               // UtilityForms.findForm = new SearchForm();
            }

            UtilityForms.findForm.Focus();
            UtilityForms.findForm.Show();
        }
    }
}
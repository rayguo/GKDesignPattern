using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogoLib;

namespace LogoApp
{
    public partial class LogoForm : Form
    {
        private Turtle turtle = new Turtle();

        public LogoForm()
        {
            InitializeComponent();

            turtleView.Turtle = turtle;
        }

        private void Forward(object sender, RepeatActionEventArgs e)
        {
            turtle.Forward(e.NTimes); 
        }

        private void Rotate(object sender, RepeatActionEventArgs e)
        {
            turtle.Rotate(e.NTimes);
        }

        private void RunMacro(object sender, EventArgs e)
        {
            // Add code here to Run the Macro
        }

        private void ClearAndReset(object sender, EventArgs e)
        {
            ClearAndReset();
        }

        private void ClearAndReset()
        {
            turtle.Reset();
            turtleView.Clear();
        }

        private void Exit(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Undo(object sender, EventArgs e)
        {
            // Add code here for undo logic
            MessageBox.Show("No undo yet..");
        }

        private void StartRecodingMacro(object sender, EventArgs e)
        {
            startRecodingMenuItem.Enabled = false;
            stopRecordingMenuItem.Enabled = true;

            // Add Code here to start the recording of the macro
        }

        private void StopRecordingMacro(object sender, EventArgs e)
        {
            startRecodingMenuItem.Enabled = true;
            stopRecordingMenuItem.Enabled = false;

            // Add Code here to stop the recording of the macro
        }
    }
}

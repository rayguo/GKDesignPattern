using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LogoLib;
using CommandPattern;

namespace LogoApp
{
    public partial class LogoForm : Form
    {
        private Turtle turtle = new Turtle();

        private CommandRecorder recorder = new CommandRecorder();
        private MacroCommand macro = new MacroCommand();
        private MacroCommand recordingMacro;

        public LogoForm()
        {
            InitializeComponent();

            turtleView.Turtle = turtle;
        }

        private void Forward(object sender, RepeatActionEventArgs e)
        {
            //turtle.Forward(e.NTimes); 

            ForwardCommand cmd = new ForwardCommand(turtle, e.NTimes);

            Execute(cmd);
        }

        private void Rotate(object sender, RepeatActionEventArgs e)
        {
          //  turtle.Rotate(e.NTimes);

            RotateCommand cmd = new RotateCommand(turtle, e.NTimes);

            Execute(cmd);
        }

        private void RunMacro(object sender, RepeatActionEventArgs e)
        {
            for (int nTime = 0; nTime < e.NTimes; nTime++)
            {
                Execute(macro);
            }
        }

        private void ClearAndReset(object sender, EventArgs e)
        {
            ClearAndReset();
            // Clear undo history
            recorder = new CommandRecorder();
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
            ClearAndReset();

            
            recorder.DeleteLastCommand();

            foreach (Command command in recorder.GetCommands())
            {
                command.Execute();
            }
           
        }

        private void StartRecording(object sender, EventArgs e)
        {
            recordingMacro = new MacroCommand();
            stopRecordingItem.Enabled = true;
            startRecordingMenuItem.Enabled = false;
        }

        private void StopRecordingMacro(object sender, EventArgs e)
        {
            macro = recordingMacro;
            recordingMacro = null;

            stopRecordingItem.Enabled = false;
           startRecordingMenuItem.Enabled = true;
        }

        private void Execute(Command command)
        {
            recorder.Execute(command);

            if (recordingMacro != null)
            {
                recordingMacro.AddCommand(command);
            }
        }

     



        

       
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using CommandPattern;
using LogoLib;

namespace LogoApp
{
    class ForwardCommand : Command
    {
        private Turtle turtle;
        private int nTimes = 0;

        public ForwardCommand(Turtle turtle , int nTimes)
        {
            this.turtle = turtle;
            this.nTimes = nTimes;
        }

        public override void Execute()
        {
            turtle.Forward(nTimes);
        }
    }

    class RotateCommand : Command
    {
        private Turtle turtle;
        private int nTimes = 0;

        public RotateCommand(Turtle turtle, int nTimes)
        {
            this.turtle = turtle;
            this.nTimes = nTimes;
        }

        public override void Execute()
        {
            turtle.Rotate(nTimes);
        }
    }

}

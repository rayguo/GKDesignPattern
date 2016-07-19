using System;
using System.Collections.Generic;
using System.Text;

namespace LogoLib
{
    public class TurtleMovedEventArgs : EventArgs
    {
        internal TurtleMovedEventArgs(Location prev, Location current)
        {
            Prev = prev;
            Current = current;
        }

        private Location prev;

        public Location Prev
        {
            get { return prev; }
            private set { prev = value; }
        }

        private Location current;

        public Location Current
        {
            get { return current; }
            private set { current = value; }
        }
    }
}

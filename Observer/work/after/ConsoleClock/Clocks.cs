using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClock
{
    public class SecondClock : Clock, ITimer
    {
        public SecondClock(int originalColumn, int originalRow, ConsoleColor? color)
            : base(originalColumn, originalRow, color)
        {
        }


        #region ITimer Members

        public void HundredthSecond()
        {
        }

        public void TenthSecond()
        {
        }

        public void Second()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
        }

        public void Minute()
        {
        }

        public void Hour()
        {
        }

        #endregion
    }

    public class HundredthSecondClock : Clock, ITimer
    {
        public HundredthSecondClock(int originalColumn, int originalRow, ConsoleColor? color)
            : base(originalColumn, originalRow, color)
        {

        }
        public void HundredthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 10, 9, 0, 2);
        }

        public void TenthSecond()
        {
        }

        public void Second()
        {
        }

        public void Minute()
        {
        }

        public void Hour()
        {
        }
    }

    public class TenthSecondClock : Clock, ITimer
    {
        public TenthSecondClock(int originalColumn, int originalRow, ConsoleColor? color)
            : base(originalColumn, originalRow, color)
        {

        }
        public void HundredthSecond()
        {
        }

        public void TenthSecond()
        {
            DateTime dt = DateTime.Now;

            WriteAt(dt.Hour, 0, 0, 2);
            WriteAt(":", 2, 0);
            WriteAt(dt.Minute, 3, 0, 2);
            WriteAt(":", 5, 0);
            WriteAt(dt.Second, 6, 0, 2);
            WriteAt(".", 8, 0);
            WriteAt(dt.Millisecond / 100, 9, 0, 1);
        }

        public void Second()
        {
        }

        public void Minute()
        {
        }

        public void Hour()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleClock
{
    public delegate void Tenths();
    public delegate void Hundredths();
    public delegate void Seconds();
    public delegate void Minutes();
    public delegate void Hours();

    public class Ticker
    {

        public event Tenths OnTenths;
        public event Hundredths OnHundredths;
        public event Seconds OnSeconds;
        public event Minutes OnMinutes;
        public event Hours OnHours;

        private bool done;

        public bool Done
        {
            get { return done; }
            set { done = value; }
        }

        public void Run()
        {
            int count = 0;
            while (!done)
            {
                Thread.Sleep(1);

                Interlocked.Increment(ref count);
                if (OnHundredths != null)
                    OnHundredths();


                if (count % 10 == 0)
                {
                    if (OnTenths != null)
                        OnTenths();
                }
                if (count % 100 == 0)
                {
                    if (OnSeconds != null)
                        OnSeconds();
                }
                if (count % 6000 == 0)
                {
                    if (OnMinutes != null)
                        OnMinutes();
                }
                if (count % 36000 == 0)
                {
                    if (OnHours != null)
                        OnHours();
                }
            }
        }
    }
}

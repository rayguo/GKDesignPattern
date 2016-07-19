using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleClock
{
    public class Ticker
    {
        List<ITimer> timers = new List<ITimer>();

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
                Thread.Sleep(0);

                Interlocked.Increment(ref count);
                foreach (ITimer timer in timers)
                {
                    timer.HundredthSecond();


                    if (count % 10 == 0)
                    {
                        timer.TenthSecond();
                    }
                    if (count % 100 == 0)
                    {
                        timer.Second();
                    }
                    if (count % 6000 == 0)
                    {
                        timer.Minute();
                    }
                    if (count % 36000 == 0)
                    {
                        timer.Hour();
                    }
                }
                if (count % 36000 == 0)
                {
                    count = 0;
                }
            }
        }

        public void RegisterTimer(ITimer clock)
        {
            timers.Add(clock);
        }

        public void DeregisterTimer(ITimer clock)
        {
            timers.Remove(clock);
        }
    }
}

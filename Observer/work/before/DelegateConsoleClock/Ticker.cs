using System.Collections.Generic;
using System.Threading;

namespace DelegateConsoleClock
{
    public delegate void Tick();

    public class Ticker
    {
        public event Tick OnTenths;

        public event Tick OnHundredths;

        public event Tick OnSeconds;

        public event Tick OnMinutes;

        public event Tick OnHours;

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

                OnHundredths?.Invoke();
                if (count % 10 == 0)
                {
                    OnTenths?.Invoke();
                }
                if (count % 100 == 0)
                {
                    OnSeconds?.Invoke();
                }
                if (count % 6000 == 0)
                {
                    OnMinutes?.Invoke();
                }
                if (count % 36000 == 0)
                {
                    OnHours?.Invoke();
                }

            }
        }
    }
}

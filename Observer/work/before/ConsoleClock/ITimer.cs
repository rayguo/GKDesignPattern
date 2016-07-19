using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleClock
{
    public interface ITimer
    {
        void HundredthSecond();
        void TenthSecond();
        void Second();
        void Minute();
        void Hour();
    }
}

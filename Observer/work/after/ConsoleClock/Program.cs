using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleClock
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            SecondClock clock = new SecondClock(0, 0, ConsoleColor.DarkYellow);
            SecondClock clock2 = new SecondClock(0, 1, ConsoleColor.Yellow);
            TenthSecondClock clock3 = new TenthSecondClock(0, 2, ConsoleColor.Green);
            HundredthSecondClock clock4 = new HundredthSecondClock(0, 3, ConsoleColor.Red);

            Ticker ticker = new Ticker();
            ticker.RegisterTimer(clock);
            ticker.RegisterTimer(clock2);
            ticker.RegisterTimer(clock3);
            ticker.RegisterTimer(clock4);

            Thread thread = new Thread(ticker.Run);
            thread.Start();

            Console.ReadLine();

            ticker.Done = true;
            thread.Join();
        }
    }
}


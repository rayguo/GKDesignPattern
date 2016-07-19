using System;
using System.Threading;

namespace DelegateConsoleClock
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
            ticker.OnSeconds += clock.Second;
            ticker.OnSeconds += clock2.Second;
            ticker.OnTenths += clock3.TenthSecond;
            ticker.OnHundredths += clock4.HundredthSecond;

            Thread thread = new Thread(ticker.Run);
            thread.Start();

            Console.ReadLine();

            ticker.Done = true;
            thread.Join();
        }
    }
}


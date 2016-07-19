using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace LoggingThrouput
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            Thread[] threads = new Thread[5];

            for (int nThread = 0; nThread < threads.Length; nThread++)
            {
                threads[nThread] = new Thread(ExerciseLogger);
                threads[nThread].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Logger.GetInstance().Close();

            timer.Stop();
            Console.WriteLine("Total time Spent logging {0}" ,  timer.Elapsed );
        }

       
        public static  void ExerciseLogger()
        {
            for (int nIter = 0; nIter < 100000; nIter++)
            {
                Logger.GetInstance().LogMsg(String.Format("Writing Message {0}", nIter));
            }

        }
    }
}

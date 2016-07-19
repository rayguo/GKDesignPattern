using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace LoggingThrouput
{
    public class Logger
    {
        [ThreadStatic]
        private static Logger instance;
        private static object creationSync = new object();
        private static List<Logger> loggers = new List<Logger>();

        private object streamSync = new object();
        
        private StreamWriter output;

        private Logger(string logFile)
        {
            output = new StreamWriter(File.Create(logFile));
        }

        public static Logger GetInstance()
        {
            if (instance == null)
            {
                CreateInstance();
            }

            return instance;
        }

         public void LogMsg(string msg)
        {            
                output.WriteLine("{0} : {1}", DateTime.Now, msg);
        }

        public void Close()
        {
            lock (creationSync)
            {
                foreach (Logger logger in loggers)
                {
                    logger.output.Close();
                }

                loggers.Clear();
            }
        }

       
        private static void CreateInstance()
        {
            // no need to double check
            // since we are creating an instance per thread
            lock(creationSync)
            {
                instance = new Logger(@String.Format("{0}log.txt" , Thread.CurrentThread.ManagedThreadId));
                loggers.Add(instance);
            }
            
        }


    }
}

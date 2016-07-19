using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;

namespace LoggingThrouput
{
    public class Logger
    {
        private static Logger instance;
        private static object creationSync = new object();
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
            lock (streamSync)
            {
                output.WriteLine("{0} : {1}", DateTime.Now, msg);
            }
        }

        public void Close()
        {
            output.Close();
        }
               
        private static void CreateInstance()
        {    
            lock(creationSync)
            {
                if (instance == null)
                {
                    instance = new Logger(string.Format("log{0}.txt", Thread.CurrentThread.ManagedThreadId));
                }
            }
            
        }
    }
}

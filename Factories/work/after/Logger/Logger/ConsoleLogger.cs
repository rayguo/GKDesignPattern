using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DM.Logger
{
    public class ConsoleLogger : Logger
    {
        LogLevel logLevel;
        // default to info
        internal ConsoleLogger():this(LogLevel.INFO)
        {}

        internal ConsoleLogger(LogLevel level)
        {
            logLevel = level;
        }

        override public void Log(string text)
        {
            Console.WriteLine(text);
        }

        override public void Log(LogLevel level, string text)
        {
            if(level >= logLevel)
                Console.WriteLine(text);
        }

        override public void Log(Exception e)
        {
            Console.WriteLine(e.Message);
        }

        override public void Log(LogLevel level, Exception e)
        {
            if (level >= logLevel)
                Console.WriteLine(e.Message);
        }
    }
}

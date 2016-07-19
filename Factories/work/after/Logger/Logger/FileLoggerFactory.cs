using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Logger
{
    public class FileLoggerFactory : LoggerFactory
    {
        override public Logger CreateLogger()
        {
            return new FileLogger();
        }

        override public Logger CreateLogger(string logFileName)
        {
            return new FileLogger(logFileName);
        }

        override public Logger CreateLogger(LogLevel level)
        {
            return new FileLogger(level);
        }

        override public Logger CreateLogger(string logFileName, LogLevel level)
        {
            return new FileLogger(logFileName, level);
        }

    }
}

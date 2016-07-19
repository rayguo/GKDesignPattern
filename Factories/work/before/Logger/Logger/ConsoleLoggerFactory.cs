using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM.Logger
{
    public class ConsoleLoggerFactory : LoggerFactory
    {
        public override Logger CreateLogger()
        {
            return new ConsoleLogger();
        }

        public override Logger CreateLogger(LogLevel level)
        {
            return new ConsoleLogger(level);
        }

        public override Logger Createlogger(string logFilename)
        {
            return new ConsoleLogger();
        }

        public override Logger CreateLogger(string logFileName, LogLevel level)
        {
            return new ConsoleLogger(level);
        }
    }
}

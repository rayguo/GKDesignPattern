using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM.Logger
{
    public class FileLoggerFactory: LoggerFactory
    {
        public override Logger CreateLogger()
        {
            return new FileLogger();
        }

        public override Logger CreateLogger(LogLevel level)
        {
            return new FileLogger(level);
        }

        public override Logger Createlogger(string logFilename)
        {
            return new FileLogger(logFilename);
        }

        public override Logger CreateLogger(string logFileName, LogLevel level)
        {
            return new FileLogger(logFileName, level);
        }
    }
}

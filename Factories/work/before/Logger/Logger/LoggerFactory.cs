using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DM.Logger
{
    public abstract class LoggerFactory
    {
        public abstract Logger CreateLogger();

        public abstract Logger CreateLogger(LogLevel level);

        public abstract Logger Createlogger(string logFilename);

        public abstract Logger CreateLogger(string logFileName, LogLevel level);
    }
}

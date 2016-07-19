using System;
using System.Collections.Generic;
using System.Text;

namespace DM.Logger
{
    abstract public class LoggerFactory
    {
        public abstract Logger CreateLogger();
        public abstract Logger CreateLogger(LogLevel level);
        public abstract Logger CreateLogger(string logFileName);
        public abstract Logger CreateLogger(string logFileName, LogLevel level);
    }
}

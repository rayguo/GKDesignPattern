using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DM.Logger
{
    public class FileLogger : Logger
    {
        string logFile;
        LogLevel logLevel;

        internal FileLogger()
            : this("logging.log", LogLevel.INFO)
        { }

        internal FileLogger(string logFileName)
            : this(logFileName, LogLevel.INFO)
        { }

        internal FileLogger(LogLevel level)
            : this("logging.log", level)
        { }

        internal FileLogger(string logFileName, LogLevel level)
        {
            this.logFile = logFileName;
            this.logLevel = level;
        }

        override public void Log(string text)
        {
            using (StreamWriter writer = new StreamWriter(logFile, true))
            {
                writer.WriteLine(text);
            }
        }

        override public void Log(LogLevel level, string text)
        {
            if (level >= logLevel)
            {
                Log(text);             
            }
        }

        override public void Log(Exception e)
        {
            Log(e.Message);
        }

        override public void Log(LogLevel level, Exception e)
        {
            Log(level, e.Message);
        }

    }
}

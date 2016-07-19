using System;
using System.Collections.Generic;
using System.Text;
using DM.Logger;
using System.Configuration;
using System.Reflection;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerFactory factory = LoadFactory("Factory");
            Logger logger1 = factory.CreateLogger();
            logger1.Log("Log message");

            Logger logger2 = factory.CreateLogger(LogLevel.ERROR);
            logger2.Log(LogLevel.WARN, "Should not see this");
            logger2.Log(LogLevel.ERROR, "Error Message");
            logger2.Log(LogLevel.FATAL, "Fatal Message");

            LoggerFactory fileFactory = LoadFactory("FileFactory");
            Logger flogger1 = fileFactory.CreateLogger();
            flogger1.Log("Log message");

            Logger flogger2 = fileFactory.CreateLogger(LogLevel.ERROR);
            flogger2.Log(LogLevel.WARN, "Should not see this");
            flogger2.Log(LogLevel.ERROR, "Error Message");
            flogger2.Log(LogLevel.FATAL, "Fatal Message");

            Logger flogger3 = fileFactory.CreateLogger("test.log", LogLevel.ERROR);
            flogger3.Log(LogLevel.WARN, "Should not see this");
            flogger3.Log(LogLevel.ERROR, "Error Message");
            flogger3.Log(LogLevel.FATAL, "Fatal Message");
        }

        private static LoggerFactory LoadFactory(string factoryName)
        {
            string factoryTypeDetails = ConfigurationManager.AppSettings[factoryName];
            string[] typeDetails;
            typeDetails = factoryTypeDetails.Split(new char[] { ',' });

            Assembly asm = Assembly.Load(typeDetails[0]);
            return (LoggerFactory)asm.CreateInstance(typeDetails[1]);
        }
    }
}

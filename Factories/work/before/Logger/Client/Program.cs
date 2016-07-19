using System;
using System.Collections.Generic;
using System.Text;
using DM.Logger;
using System.Reflection;
using static System.Configuration.ConfigurationSettings;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //LoggerFactory factory = new ConsoleLoggerFactory();
            LoggerFactory factory = LoadFactory("CFactory");

            Logger logger1 = factory.CreateLogger();
            logger1.Log("Log message");

            Logger logger2 = factory.CreateLogger(LogLevel.ERROR);
            logger2.Log(LogLevel.WARN, "Should not see this");
            logger2.Log(LogLevel.ERROR, "Error Message");
            logger2.Log(LogLevel.FATAL, "Fatal Message");


            //LoggerFactory ffactory = new FileLoggerFactory();
            LoggerFactory ffactory = LoadFactory("FFactory");
            Logger flogger1 = ffactory.CreateLogger();
            flogger1.Log("Log message");

            Logger flogger2 = ffactory.CreateLogger("D:\\git\\Labs\\Factories\\work\\before\\Logger\\logging.log", LogLevel.ERROR);
            flogger2.Log(LogLevel.WARN, "Should not see this");
            flogger2.Log(LogLevel.ERROR, "Error Message. Go Pikachu!");
            flogger2.Log(LogLevel.FATAL, "Fatal Message");

        }

        static LoggerFactory LoadFactory(string factoryName)
        {
            string factoryTypeDetails = AppSettings[factoryName];
            string[] typeDetails;
            typeDetails = factoryTypeDetails.Split(new char[] { ',' });
            Assembly asm = Assembly.Load(typeDetails[0]);

            return (LoggerFactory)asm.CreateInstance(typeDetails[1]);
        }
    }
}

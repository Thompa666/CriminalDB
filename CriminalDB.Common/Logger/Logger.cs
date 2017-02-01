using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.Common.Logger
{
    public class Logger : ILogger
    {
        private string logfilepath;
        public string LogFilePath
        {
            get
            {
                return logfilepath;
            }

            set
            {
                logfilepath = value;
            }
        }

        private static Logger logger;

        private Logger()
        {

        }

        public static Logger GetLoggerInstance()
        {
            if (logger == null)
                logger = new Logger();
            return logger;
        }

        public static void LogInformation(string message)
        {
            Log($"INFORMATION: {message}");
        }

        public static void LogError(string message)
        {
            Log($"ERROR: {message}");
        }

        private static void Log(string message)
        {
            message = ($"{DateTime.Now.ToString()} - {message}");
        }


    #region InterfaceImp

        Logger ILogger.GetLoggerInstance()
        {
            return Logger.GetLoggerInstance();
        }

        void ILogger.LogError(string message)
        {
            Logger.LogError(message);
        }

        void ILogger.LogInformation(string message)
        {
            Logger.LogInformation(message);
        }
        
    #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriminalDB.Common.Logger
{
    public interface ILogger
    {
        string LogFilePath
        {
            get;
            set;
        }

        Logger GetLoggerInstance();
        void LogInformation(string message);
        void LogError(string message);
    }
}

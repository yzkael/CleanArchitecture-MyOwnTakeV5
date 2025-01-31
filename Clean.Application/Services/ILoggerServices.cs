using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clean.Application.Services
{
    public interface ILoggerServices
    {
        public void LogInfo(string message);
        public void LogError(string message);
        public void LogWarn(string message);
        public void LogDebug(string message);
    }
}
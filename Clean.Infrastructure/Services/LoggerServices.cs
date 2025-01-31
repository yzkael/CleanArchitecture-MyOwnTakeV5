using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clean.Application.Services;
using Microsoft.Extensions.Logging;

namespace Clean.Infrastructure.Services
{
    public class LoggerServices : ILoggerServices
    {
        private readonly ILogger<LoggerServices> _logger;

        public LoggerServices(ILogger<LoggerServices> logger)
        {
            _logger = logger;
        }

        public void LogDebug(string message)
        {
            _logger.LogDebug(message);
        }

        public void LogError(string message)
        {
            _logger.LogError(message);
        }

        public void LogInfo(string message)
        {
            _logger.LogInformation(message);
        }

        public void LogWarn(string message)
        {
            _logger.LogWarning(message);
        }
    }
}
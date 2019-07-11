using NLog;
using System;
using NLogLogger = NLog.Logger;

namespace CarAPI.Web.Infrastructure.Logging
{
    public class Logger<T> : ILogger<T>
    {
        private const string LoggerName = "carAPIFileLogger";
        private readonly NLogLogger _logger;

        public Logger()
        {
            var fullNameLogger = $"{LoggerName}.{typeof(T).FullName}";
            _logger = LogManager.GetLogger(fullNameLogger);
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(message, args);
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(message, args);
        }

        public void Error(string message, Exception exception, params object[] args)
        {
            _logger.Error(message, exception, args);
        }
    }
}

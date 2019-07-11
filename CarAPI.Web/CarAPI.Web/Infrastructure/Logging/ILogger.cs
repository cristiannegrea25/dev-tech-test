using System;

namespace CarAPI.Web.Infrastructure.Logging
{
    public interface ILogger<T>
    {
        void Info(string message, params object[] args);
        void Error(string message, params object[] args);
        void Error(string message, Exception exception, params object[] args);
    }
}

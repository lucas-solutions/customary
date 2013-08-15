using System;

namespace Custom.Diagnostics
{
    public class LogglyException : Exception
    {
        public LogglyException() { }
        public LogglyException(string message) : base(message) { }
        public LogglyException(string message, Exception innerException) : base(message, innerException) { }
    }
}
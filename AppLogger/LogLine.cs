using System;

namespace AppLogger
{
    internal class LogLine
    {
        internal static string Separator { get; set; } = " | ";
        internal LogLevel LogLevel { get; private set; }
        internal string Message { get; private set; }
        internal Exception Error { get; private set; }

        internal LogLine()
        {
            Message = "";
            Error = null;
            LogLevel = LogLevel.INFO;
        }

        internal LogLine(string message, LogLevel level = LogLevel.INFO)
        {
            Message = message;
            Error = null;
            LogLevel = LogLevel.INFO;
        }

        internal LogLine(string message, Exception error = null, LogLevel level = LogLevel.ERROR)
        {
            Message = message;
            Error = error;
            LogLevel = level;
        }

        public override string ToString()
        {
            string[] fields = new string[]
            {
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ffff"),
                LogLevel.ToString(),
                Message,
                Error?.Message,
                Error?.InnerException?.Message,
                (Error != null) ?
                    "\r\n" + Error.StackTrace
                    : ""
            };

            return string.Join(Separator, fields);
        }
    }
}

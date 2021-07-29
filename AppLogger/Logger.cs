using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AppLogger
{
    public class Logger
    {
        public string FileName { get; private set; }
        public bool IsLogging { get; private set; }
        public bool LoggingEnabled { get; private set; }
        private Queue<LogLine> LogQueue { get; set; }
        
        public Logger(string fileName, bool enabled, string separator)
        {
            LoggingEnabled = enabled;
            if (LoggingEnabled)
            {
                LogQueue = new Queue<LogLine>();
                FileName = fileName;
                IsLogging = false;
                LogLine.Separator = separator;
            }
        }

        public Logger(string fileName, bool enabled) 
            : this(fileName, enabled, " | ") { }

        // Starts logging items in the LogQueue
        public void Start()
        {
            if (!IsLogging && LoggingEnabled)
            {
                IsLogging = true;
                ProcessQueue();
            }
        }

        // Stops logging items in the LogQueue
        public void Stop()
        {
            IsLogging = false;
        }

        // Adds a custom log line to the Log Queue
        public void LogAsync(string message, LogLevel level = LogLevel.INFO) => Task.Run(() => Log(message, level));
        public void Log(string message, LogLevel level = LogLevel.INFO)
        {
            Enqueue(new LogLine(message, level));
        }

        // Adds an Exception log line to the Log Queue
        public void LogErrorAsync(string message, Exception error) => Task.Run(() => LogError(message, error));
        public void LogError(string message, Exception error)
        {
            Enqueue(new LogLine(message, error));
        }

        // Adds a log line to the Log Queue
        private void Enqueue(LogLine line)
        {
            try
            {
                if (LoggingEnabled)
                {
                    lock (LogQueue)
                    { LogQueue.Enqueue(line); }
                }
            }
            catch { /* Do nothing */ }
        }

        private LogLine Dequeue()
        {
            lock (LogQueue)
            { return LogQueue.Dequeue(); }
        }

        // Start processing the LogQueue asynchronously
        private void ProcessQueue() => Task.Run(() =>
        {
            if (LoggingEnabled)
                try
                {
                    while (IsLogging)
                        if (LogQueue.Count > 0)
                            WriteLine(Dequeue().ToString());
                }
                catch { /* Do nothing */ }
        });

        private void WriteLine(string text)
        {
            File.AppendAllText(FileName, text + "\r\n");
        }
    }
}

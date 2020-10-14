using System;
using System.IO;
using Lib.Core;

namespace Lib.Win32
{
    public class LoggingService : ILoggingService
    {
        public void WriteExceptionInConsole(Exception ex)
        {
            Console.WriteLine(GetDateString());
            Console.WriteLine(ex.Message);
            Console.WriteLine(ex.StackTrace);
            Console.WriteLine();
        }

        public void WriteExceptionInLogs(string fileName, Exception ex)
        {
            File.AppendAllText(fileName,  $"{DateTime.Now.ToShortDateString()} - {DateTime.Now.ToShortTimeString()}");
            File.AppendAllText(fileName, "\r\n");
            File.AppendAllText(fileName, ex.Message);
            File.AppendAllText(fileName, "\r\n");
            File.AppendAllText(fileName, ex.StackTrace);
            File.AppendAllText(fileName, "\r\n");

            if (ex.InnerException != null)
            {
                File.AppendAllText(fileName, ex.InnerException.Message);
                File.AppendAllText(fileName, "\r\n");
                File.AppendAllText(fileName, ex.InnerException.StackTrace);
                File.AppendAllText(fileName, "\r\n");
            }

            File.AppendAllText(fileName, "\r\n");
        }

        public void WriteInConsole(string text, bool showDate = true, bool goBack = false)
        {
            var suffix = "";
            if (showDate)
            {
                text = $"{GetDateString()} : {text}";
            }

            if (goBack)
            {
                text = $"\r{text}";
            }

            System.Console.Write($"{text} {suffix}");
        }

        public void WriteLineInConsole(string text, bool showDate = true, bool goBack = false)
        {
            var suffix = "";
            if (showDate)
            {
                text = $"{GetDateString()} : {text}";
            }

            if (goBack)
            {
                text = $"\r{text}";
            }

            System.Console.WriteLine($"{text} {suffix}");
        }

        private string GetDateString()
        {
            return $"{DateTime.Now.ToLongDateString()} {DateTime.Now.ToLongTimeString()}";
        }
    }
}
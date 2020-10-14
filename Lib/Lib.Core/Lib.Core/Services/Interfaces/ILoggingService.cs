using System;

namespace Lib.Core
{
    public interface ILoggingService
    {
        void WriteExceptionInConsole(Exception ex);

        void WriteExceptionInLogs(string fileName, Exception ex);
        
        void WriteInConsole(string text, bool showDate = true, bool goBack = false);

        void WriteLineInConsole(string text, bool showDate = true, bool goBack = false);
    }
}
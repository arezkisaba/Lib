using System.Collections.Generic;

namespace Lib.Core
{
	public interface ISystemProcessService
	{
        List<SystemProcessModel> GetAll();

        List<SystemProcessModel> GetByName(string name);

        bool Start(string filePath, string arguments = null, bool waitForExit = true);

        bool StartScript(string filePath);
        
        void Stop(string name);

        void Kill(string name);

        SystemProcessModel GetForegroundProcess();

        void KillProcessesWithSameNameThanCurrent();

        void StartOnScreenKeyboard();

        void StartWebBrowser(string url);
    }
}
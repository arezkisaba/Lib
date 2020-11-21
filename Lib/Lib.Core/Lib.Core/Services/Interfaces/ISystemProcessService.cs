using System.Collections.Generic;

namespace Lib.Core
{
	public interface ISystemProcessService
	{
        List<SystemProcessModel> GetAll();

        List<SystemProcessModel> GetByName(string name);

        void Start(string filePath);

        bool Start(string filePath, string arguments);

        bool StartScript(string filePath);

        void Stop(string name);

        SystemProcessModel GetForegroundProcess();

        void KillProcessesWithSameNameThanCurrent();

        void StartOnScreenKeyboard();

        void StartWebBrowser(string url);
    }
}
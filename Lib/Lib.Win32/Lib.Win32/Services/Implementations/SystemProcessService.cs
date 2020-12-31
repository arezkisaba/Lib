using Lib.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lib.Win32
{
    public class SystemProcessService : ISystemProcessService
    {
        public List<SystemProcessModel> GetAll()
        {
            return Process.GetProcesses().Select(obj => new SystemProcessModel(obj.Id, obj.ProcessName)).ToList();
        }

        public List<SystemProcessModel> GetByName(string name)
        {
            return Process.GetProcessesByName(name).Select(obj => new SystemProcessModel(obj.Id, obj.ProcessName)).ToList();
        }

        public bool Start(string filePath, string arguments = null, bool waitForExit = true)
        {
            var process = new Process();
            process.StartInfo.FileName = filePath;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

            try
            {
                process.Start();

                if (waitForExit)
                {
                    process.WaitForExit();
                    return process.ExitCode == 0;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool StartScript(string filePath)
        {
            var process = new Process();
            process.StartInfo.FileName = "powershell.exe";
            process.StartInfo.Arguments = $"-NoProfile -ExecutionPolicy unrestricted -file \"{filePath}\"";

            try
            {
                process.Start();
                process.WaitForExit();
            }
            catch (Exception)
            {
                return false;
            }


            return process.ExitCode == 0;
        }

        public void Stop(string name)
        {
            var processes = Process.GetProcessesByName(name);
            foreach (var process in processes)
            {
                process.CloseMainWindow();
                process.Close();
            }
        }

        public void Kill(string name)
        {
            var processes = Process.GetProcessesByName(name);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        public SystemProcessModel GetForegroundProcess()
        {
            var hwnd = NativeMethods.Window.GetForegroundWindow();
            var process = GetProcess(hwnd);
            return new SystemProcessModel(process.Id, process.ProcessName);
        }

        public void KillProcessesWithSameNameThanCurrent()
        {
            var currentProcess = Process.GetCurrentProcess();
            var processes = Process.GetProcessesByName(currentProcess.ProcessName);
            if (processes.Any())
            {
                foreach (var process in processes.Where(obj => obj.Id != currentProcess.Id))
                {
                    process.Kill();
                }
            }
        }

        public void StartOnScreenKeyboard()
        {
            var path64 = @"C:\Windows\WinSxS\amd64_microsoft-windows-osk_31bf3856ad364e35_10.0.10586.0_none_37426bc50445e4b2\osk.exe";
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
            Process.Start(path);
        }

        public void StartWebBrowser(string url)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                Process.Start(new ProcessStartInfo("cmd", $"/c start {url}"));
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                Process.Start("xdg-open", url);
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                Process.Start("open", url);
            }
            else
            {
            }
        }

        #region Private

        private Process GetProcess(int processId)
        {
            try
            {
                return Process.GetProcessById(processId);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Process GetProcess(IntPtr hwnd)
        {
            uint processId;
            NativeMethods.Window.GetWindowThreadProcessId(hwnd, out processId);
            return GetProcess((int)processId);
        }

        private List<string> GetChildProcesses(IntPtr parent)
        {
            var result = new List<string>();
            var listHandle = GCHandle.Alloc(result);

            try
            {
                var childProc = new NativeMethods.Window.EnumWindowsProc(EnumWindow);
                NativeMethods.Window.EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
            }
            finally
            {
                if (listHandle.IsAllocated)
                {
                    listHandle.Free();
                }
            }
            return result;
        }

        private bool IsWindowInFullscreenMode(IntPtr hwnd)
        {
            NativeMethods.Window.RECT rect;
            NativeMethods.Window.RECT desktopRect;
            var desktopHwnd = NativeMethods.Window.GetDesktopWindow();

            NativeMethods.Window.GetWindowRect(hwnd, out rect);
            NativeMethods.Window.GetWindowRect(desktopHwnd, out desktopRect);

            if (rect.Bottom == desktopRect.Bottom)
            {
                return true;
            }

            return false;
        }

        private bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            var gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<string>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }

            var process = GetProcess(handle);
            list.Add(process.ProcessName);
            return true;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using static Lib.Win32.NativeMethods;

namespace Lib.Win32
{
    public static class ProcessesHelper
    {
        public static void Start(string filename)
        {
            Process.Start(filename);
        }

        public static bool Start(string filename, string arguments, ProcessWindowStyle processWindowStyle = ProcessWindowStyle.Normal)
        {
            var process = new Process();
            process.StartInfo.FileName = filename;
            process.StartInfo.WindowStyle = processWindowStyle;
            if (!string.IsNullOrEmpty(arguments))
            {
                process.StartInfo.Arguments = arguments;
            }

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

        public static void Stop(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            foreach (var process in processes)
            {
                process.Kill();
            }
        }

        public static Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        public static Process[] GetProcesses(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        public static Process GetForegroundProcess()
        {
            var hwnd = NativeMethods.GetForegroundWindow();
            return GetProcess(hwnd);
        }

        public static bool IsForegroundWindowInFullscreenMode()
        {
            var hwnd = NativeMethods.GetForegroundWindow();
            return IsWindowInFullscreenMode(hwnd);
        }

        public static bool IsProcessInFullscreenMode(string processName)
        {
            var processes = GetProcesses(processName);
            if (processes.Length <= 0)
            {
                return false;
            }

            return IsWindowInFullscreenMode(processes.FirstOrDefault().MainWindowHandle);
        }

        public static void KillDuplicateProcesses()
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

        public static List<string> GetChildProcesses(IntPtr parent)
        {
            var result = new List<string>();
            var listHandle = GCHandle.Alloc(result);

            try
            {
                var childProc = new EnumWindowsProc(EnumWindow);
                EnumChildWindows(parent, childProc, GCHandle.ToIntPtr(listHandle));
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

        public static void Exit()
        {
        }

        #region Private

        private static Process GetProcess(int processId)
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

        private static Process GetProcess(IntPtr hwnd)
        {
            uint processId;
            NativeMethods.GetWindowThreadProcessId(hwnd, out processId);
            return GetProcess((int)processId);
        }

        private static bool IsProcessInFullscreenMode(int processId)
        {
            var process = GetProcess(processId);
            if (process == null)
            {
                return false;
            }

            return IsWindowInFullscreenMode(process.MainWindowHandle);
        }

        private static bool IsWindowInFullscreenMode(IntPtr hwnd)
        {
            RECT rect;
            RECT desktopRect;
            var desktopHwnd = NativeMethods.GetDesktopWindow();

            NativeMethods.GetWindowRect(hwnd, out rect);
            NativeMethods.GetWindowRect(desktopHwnd, out desktopRect);

            if (rect.Bottom == desktopRect.Bottom)
            {
                return true;
            }

            return false;
        }

        private static bool EnumWindow(IntPtr handle, IntPtr pointer)
        {
            var gch = GCHandle.FromIntPtr(pointer);
            var list = gch.Target as List<string>;
            if (list == null)
            {
                throw new InvalidCastException("GCHandle Target could not be cast as List<IntPtr>");
            }

            var process = ProcessesHelper.GetProcess(handle);
            list.Add(process.ProcessName);
            return true;
        }

        #endregion

        #region Application specific

        public static void StartOSK()
        {
            var path64 = @"C:\Windows\WinSxS\amd64_microsoft-windows-osk_31bf3856ad364e35_10.0.10586.0_none_37426bc50445e4b2\osk.exe";
            var path32 = @"C:\windows\system32\osk.exe";
            var path = (Environment.Is64BitOperatingSystem) ? path64 : path32;
            Process.Start(path);
        }

        public static void StartWebBrowser(string url)
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

        #endregion
    }
}
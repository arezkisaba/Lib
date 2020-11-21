using Lib.Core;
using System;

namespace Lib.Win32
{
    public class PowerService : IPowerService
    {
        public bool Shutdown()
        {
            NativeMethods.Privilege.TokPriv1Luid tp;
            var hproc = NativeMethods.Process.GetCurrentProcess();
            var htok = IntPtr.Zero;
            var result = NativeMethods.Process.OpenProcessToken(hproc, NativeMethods.Privilege.TOKEN_ADJUST_PRIVILEGES | NativeMethods.Privilege.TOKEN_QUERY, ref htok);
            if (!result)
            {
                return false;
            }
            
            tp.Count = 1;
            tp.Luid = 0;
            tp.Attr = NativeMethods.Privilege.SE_PRIVILEGE_ENABLED;
            result = NativeMethods.Privilege.LookupPrivilegeValue(null, NativeMethods.Privilege.SE_SHUTDOWN_NAME, ref tp.Luid);
            if (!result)
            {
                return false;
            }

            result = NativeMethods.Privilege.AdjustTokenPrivileges(htok, false, ref tp, 0, IntPtr.Zero, IntPtr.Zero);
            if (!result)
            {
                return false;
            }

            result = NativeMethods.Power.ExitWindowsEx(NativeMethods.Power.EWX_POWEROFF | NativeMethods.Power.EWX_FORCE, 0);
            return result;
        }
    }
}
using System;
using System.Runtime.InteropServices;
using static Lib.Win32.NativeMethods.Clipboard;

namespace Lib.Win32
{
    public class ClipboardService
    {
        public void SetText(string text)
        {
            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(text);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
}

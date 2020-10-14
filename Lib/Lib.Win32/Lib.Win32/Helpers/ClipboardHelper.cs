using System;
using System.Runtime.InteropServices;
using static Lib.Win32.NativeMethods;

namespace Lib.Win32
{
    public static class ClipboardHelper
    {
        public static void SetText(string text)
        {
            OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(text);
            SetClipboardData(13, ptr);
            CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
} 
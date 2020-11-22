using Lib.Core;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Lib.Win32
{
    public class SystemClipboardService : ISystemClipboardService
    {
        public string GetText()
        {
            if (!NativeMethods.Clipboard.IsClipboardFormatAvailable(NativeMethods.Clipboard.CF_UNICODETEXT))
            {
                return null;
            }

            try
            {
                if (!NativeMethods.Clipboard.OpenClipboard(IntPtr.Zero))
                {
                    return null;
                }

                var handle = NativeMethods.Clipboard.GetClipboardData(NativeMethods.Clipboard.CF_UNICODETEXT);
                if (handle == IntPtr.Zero)
                {
                    return null;
                }

                var pointer = IntPtr.Zero;

                try
                {
                    pointer = NativeMethods.Clipboard.GlobalLock(handle);
                    if (pointer == IntPtr.Zero)
                    {
                        return null;
                    }

                    var size = NativeMethods.Clipboard.GlobalSize(handle);
                    var buff = new byte[size];

                    Marshal.Copy(pointer, buff, 0, size);

                    return Encoding.Unicode.GetString(buff).TrimEnd('\0');
                }
                finally
                {
                    if (pointer != IntPtr.Zero)
                    {
                        NativeMethods.Clipboard.GlobalUnlock(handle);
                    }
                }
            }
            finally
            {
                NativeMethods.Clipboard.CloseClipboard();
            }
        }

        public void SetText(string text)
        {
            NativeMethods.Clipboard.OpenClipboard(IntPtr.Zero);
            var ptr = Marshal.StringToHGlobalUni(text);
            NativeMethods.Clipboard.SetClipboardData(13, ptr);
            NativeMethods.Clipboard.CloseClipboard();
            Marshal.FreeHGlobal(ptr);
        }
    }
}

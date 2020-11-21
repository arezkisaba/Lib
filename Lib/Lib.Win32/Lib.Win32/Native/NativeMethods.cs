using System;
using System.Runtime.InteropServices;

namespace Lib.Win32
{
    public static class NativeMethods
    {
        public static class Clipboard
        {
            [DllImport("user32.dll")]
            public static extern bool OpenClipboard(IntPtr hWndNewOwner);

            [DllImport("user32.dll")]
            public static extern bool CloseClipboard();

            [DllImport("user32.dll")]
            public static extern bool SetClipboardData(uint uFormat, IntPtr data);
        }

        public static class Display
        {
            public const int ENUM_CURRENT_SETTINGS = -1;
            public const int DISP_CHANGE_SUCCESSFUL = 0;
            public const int DISP_CHANGE_BADMODE = -2;
            public const int DISP_CHANGE_FAILED = -1;
            public const int DISP_CHANGE_RESTART = 1;

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumDisplaySettings([param: MarshalAs(UnmanagedType.LPTStr)] string lpszDeviceName, [param: MarshalAs(UnmanagedType.U4)] int iModeNum, [In, Out] ref DEVMODE lpDevMode);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.I4)]
            public static extern int ChangeDisplaySettings([In, Out] ref DEVMODE lpDevMode, [param: MarshalAs(UnmanagedType.U4)] uint dwflags);

            [StructLayout(LayoutKind.Sequential,
            CharSet = CharSet.Ansi)]
            public struct DEVMODE
            {
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string dmDeviceName;

                [MarshalAs(UnmanagedType.U2)]
                public UInt16 dmSpecVersion;

                [MarshalAs(UnmanagedType.U2)]
                public UInt16 dmDriverVersion;

                [MarshalAs(UnmanagedType.U2)]
                public UInt16 dmSize;

                [MarshalAs(UnmanagedType.U2)]
                public UInt16 dmDriverExtra;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmFields;

                public POINTL dmPosition;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmDisplayOrientation;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmDisplayFixedOutput;

                [MarshalAs(UnmanagedType.I2)]
                public Int16 dmColor;

                [MarshalAs(UnmanagedType.I2)]
                public Int16 dmDuplex;

                [MarshalAs(UnmanagedType.I2)]
                public Int16 dmYResolution;

                [MarshalAs(UnmanagedType.I2)]
                public Int16 dmTTOption;

                [MarshalAs(UnmanagedType.I2)]
                public Int16 dmCollate;

                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
                public string dmFormName;

                [MarshalAs(UnmanagedType.U2)]
                public UInt16 dmLogPixels;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmBitsPerPel;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmPelsWidth;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmPelsHeight;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmDisplayFlags;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmDisplayFrequency;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmICMMethod;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmICMIntent;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmMediaType;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmDitherType;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmReserved1;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmReserved2;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmPanningWidth;

                [MarshalAs(UnmanagedType.U4)]
                public UInt32 dmPanningHeight;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct POINTL
            {
                [MarshalAs(UnmanagedType.I4)]
                public int x;
                [MarshalAs(UnmanagedType.I4)]
                public int y;
            }
        }

        public static class Keyboard
        {
            public const int VK_VOLUME_MUTE = 0xAD;
            public const int VK_VOLUME_DOWN = 0xAE;
            public const int VK_VOLUME_UP = 0xAF;

            [DllImport("user32.dll")]
            public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        }

        public static class Mouse
        {
            [DllImport("user32.dll")]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        }

        public static class Network
        {
            [DllImport("wininet.dll")]
            public static extern bool InternetGetConnectedState(out int Description, int ReservedValue);
        }

        public static class Service
        {
            public const uint SERVICE_NO_CHANGE = 0xFFFFFFFF;
            public const uint SERVICE_QUERY_CONFIG = 0x00000001;
            public const uint SERVICE_CHANGE_CONFIG = 0x00000002;
            public const uint SC_MANAGER_ALL_ACCESS = 0x000F003F;

            [DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern Boolean ChangeServiceConfig(IntPtr hService, UInt32 nServiceType, UInt32 nStartType, UInt32 nErrorControl, String lpBinaryPathName, String lpLoadOrderGroup, IntPtr lpdwTagId, [In] char[] lpDependencies, String lpServiceStartName, String lpPassword, String lpDisplayName);

            [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Auto)]
            public static extern IntPtr OpenService(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

            [DllImport("advapi32.dll", EntryPoint = "OpenSCManagerW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern IntPtr OpenSCManager(string machineName, string databaseName, uint dwAccess);

            [DllImport("advapi32.dll", EntryPoint = "CloseServiceHandle")]
            public static extern int CloseServiceHandle(IntPtr hSCObject);
        }

        public static class Window
        {

            public const int SW_HIDE = 0;
            public const int SW_SHOWNORMAL = 1;
            public const int SW_NORMAL = 1;
            public const int SW_SHOWMINIMIZED = 2;
            public const int SW_SHOWMAXIMIZED = 3;
            public const int SW_MAXIMIZE = 3;
            public const int SW_SHOWNOACTIVATE = 4;
            public const int SW_SHOW = 5;
            public const int SW_MINIMIZE = 6;
            public const int SW_SHOWMINNOACTIVE = 7;
            public const int SW_SHOWNA = 8;
            public const int SW_RESTORE = 9;

            [StructLayout(LayoutKind.Sequential)]
            public struct RECT
            {
                public int Left;
                public int Top;
                public int Right;
                public int Bottom;
            }

            public struct WINDOWPLACEMENT
            {
                public int length;
                public int flags;
                public int showCmd;
                public System.Drawing.Point ptMinPosition;
                public System.Drawing.Point ptMaxPosition;
                public System.Drawing.Rectangle rcNormalPosition;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll")]
            public static extern IntPtr GetDesktopWindow();

            [DllImport("user32.dll")]
            public static extern IntPtr GetShellWindow();

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EnumChildWindows(IntPtr hwndParent, EnumWindowsProc lpEnumFunc, IntPtr lParam);
            public delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int GetWindowRect(IntPtr hwnd, out RECT rc);

            [DllImport("user32.dll")]
            public static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT lpwndpl);

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowThreadProcessId(IntPtr hWnd, out uint processId);

            [DllImport("user32.dll")]
            public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        }
    }
}
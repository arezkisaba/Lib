using System;
using System.Runtime.InteropServices;

namespace Lib.Win32
{
    public static class NativeMethods
    {
        public static class Clipboard
        {
            public const uint CF_UNICODETEXT = 13U;

            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsClipboardFormatAvailable(uint format);

            [DllImport("User32.dll", SetLastError = true)]
            public static extern IntPtr GetClipboardData(uint uFormat);

            [DllImport("user32.dll")]
            public static extern bool SetClipboardData(uint uFormat, IntPtr data);

            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool OpenClipboard(IntPtr hWndNewOwner);

            [DllImport("User32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool CloseClipboard();

            [DllImport("Kernel32.dll", SetLastError = true)]
            public static extern IntPtr GlobalLock(IntPtr hMem);

            [DllImport("Kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GlobalUnlock(IntPtr hMem);

            [DllImport("Kernel32.dll", SetLastError = true)]
            public static extern int GlobalSize(IntPtr hMem);
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

        public static class Message
        {
            [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
            public static extern int MessageBox(IntPtr hwnd, String text, String caption, uint type);
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

        public static class Power
        {
            public const int EWX_LOGOFF = 0x00000000;
            public const int EWX_SHUTDOWN = 0x00000001;
            public const int EWX_REBOOT = 0x00000002;
            public const int EWX_FORCE = 0x00000004;
            public const int EWX_POWEROFF = 0x00000008;
            public const int EWX_FORCEIFHUNG = 0x00000010;

            [Flags]
            public enum ShutdownReason : uint
            {
                // Microsoft major reasons.
                SHTDN_REASON_MAJOR_OTHER = 0x00000000,
                SHTDN_REASON_MAJOR_NONE = 0x00000000,
                SHTDN_REASON_MAJOR_HARDWARE = 0x00010000,
                SHTDN_REASON_MAJOR_OPERATINGSYSTEM = 0x00020000,
                SHTDN_REASON_MAJOR_SOFTWARE = 0x00030000,
                SHTDN_REASON_MAJOR_APPLICATION = 0x00040000,
                SHTDN_REASON_MAJOR_SYSTEM = 0x00050000,
                SHTDN_REASON_MAJOR_POWER = 0x00060000,
                SHTDN_REASON_MAJOR_LEGACY_API = 0x00070000,

                // Microsoft minor reasons.
                SHTDN_REASON_MINOR_OTHER = 0x00000000,
                SHTDN_REASON_MINOR_NONE = 0x000000ff,
                SHTDN_REASON_MINOR_MAINTENANCE = 0x00000001,
                SHTDN_REASON_MINOR_INSTALLATION = 0x00000002,
                SHTDN_REASON_MINOR_UPGRADE = 0x00000003,
                SHTDN_REASON_MINOR_RECONFIG = 0x00000004,
                SHTDN_REASON_MINOR_HUNG = 0x00000005,
                SHTDN_REASON_MINOR_UNSTABLE = 0x00000006,
                SHTDN_REASON_MINOR_DISK = 0x00000007,
                SHTDN_REASON_MINOR_PROCESSOR = 0x00000008,
                SHTDN_REASON_MINOR_NETWORKCARD = 0x00000000,
                SHTDN_REASON_MINOR_POWER_SUPPLY = 0x0000000a,
                SHTDN_REASON_MINOR_CORDUNPLUGGED = 0x0000000b,
                SHTDN_REASON_MINOR_ENVIRONMENT = 0x0000000c,
                SHTDN_REASON_MINOR_HARDWARE_DRIVER = 0x0000000d,
                SHTDN_REASON_MINOR_OTHERDRIVER = 0x0000000e,
                SHTDN_REASON_MINOR_BLUESCREEN = 0x0000000F,
                SHTDN_REASON_MINOR_SERVICEPACK = 0x00000010,
                SHTDN_REASON_MINOR_HOTFIX = 0x00000011,
                SHTDN_REASON_MINOR_SECURITYFIX = 0x00000012,
                SHTDN_REASON_MINOR_SECURITY = 0x00000013,
                SHTDN_REASON_MINOR_NETWORK_CONNECTIVITY = 0x00000014,
                SHTDN_REASON_MINOR_WMI = 0x00000015,
                SHTDN_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000016,
                SHTDN_REASON_MINOR_HOTFIX_UNINSTALL = 0x00000017,
                SHTDN_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000018,
                SHTDN_REASON_MINOR_MMC = 0x00000019,
                SHTDN_REASON_MINOR_TERMSRV = 0x00000020,

                // Flags that end up in the event log code.
                SHTDN_REASON_FLAG_USER_DEFINED = 0x40000000,
                SHTDN_REASON_FLAG_PLANNED = 0x80000000,
                SHTDN_REASON_UNKNOWN = SHTDN_REASON_MINOR_NONE,
                SHTDN_REASON_LEGACY_API = (SHTDN_REASON_MAJOR_LEGACY_API | SHTDN_REASON_FLAG_PLANNED),

                // This mask cuts out UI flags.
                SHTDN_REASON_VALID_BIT_MASK = 0xc0ffffff
            }

            [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
            public static extern bool ExitWindowsEx(int flg, int rea);

            [DllImport("advapi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool InitiateSystemShutdownEx(string lpMachineName, string lpMessage, uint dwTimeout, bool bForceAppsClosed, bool bRebootAfterShutdown, ShutdownReason dwReason);
        }

        public static class Privilege
        {
            public const int SE_PRIVILEGE_ENABLED = 0x00000002;
            public const int TOKEN_QUERY = 0x00000008;
            public const int TOKEN_ADJUST_PRIVILEGES = 0x00000020;
            public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

            [StructLayout(LayoutKind.Sequential, Pack = 1)]
            internal struct TokPriv1Luid
            {
                public int Count;
                public long Luid;
                public int Attr;
            }

            [DllImport("advapi32.dll", SetLastError = true)]
            internal static extern bool LookupPrivilegeValue(string host, string name,
            ref long pluid);

            [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
            internal static extern bool AdjustTokenPrivileges(IntPtr htok, bool disall, ref TokPriv1Luid newst, int len, IntPtr prev, IntPtr relen);
        }

        public static class Process
        {
            [DllImport("kernel32.dll", ExactSpelling = true)]
            internal static extern IntPtr GetCurrentProcess();

            [DllImport("advapi32.dll", ExactSpelling = true, SetLastError = true)]
            internal static extern bool OpenProcessToken(IntPtr h, int acc, ref IntPtr phtok);
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
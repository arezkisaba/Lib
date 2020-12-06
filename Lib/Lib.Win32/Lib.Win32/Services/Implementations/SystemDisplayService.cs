using Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Lib.Win32
{
    public class SystemDisplayService : ISystemDisplayService
    {
        public List<SystemDisplayModel> GetAll()
        {
            var modeIndex = 0;
            var mode = new NativeMethods.Display.DEVMODE();
            var displays = new List<SystemDisplayModel>();
            mode.dmSize = (ushort)Marshal.SizeOf(mode);

            while (NativeMethods.Display.EnumDisplaySettings(null, modeIndex, ref mode))
            {
                var display = new SystemDisplayModel((int)mode.dmPelsWidth, (int)mode.dmPelsHeight, (int)mode.dmBitsPerPel);
                if (!displays.Any(__ => __.Width == display.Width && __.Height == display.Height && __.BitCount == display.BitCount))
                {
                    displays.Add(display);
                }

                modeIndex++;
            }

            if (!displays.Any())
            {
                throw new InvalidOperationException("EnumDisplaySettings()");
            }

            return displays;
        }

        public SystemDisplayModel GetCurrent()
        {
            var mode = new NativeMethods.Display.DEVMODE();
            mode.dmSize = (ushort)Marshal.SizeOf(mode);

            if (NativeMethods.Display.EnumDisplaySettings(null, NativeMethods.Display.ENUM_CURRENT_SETTINGS, ref mode))
            {
                return new SystemDisplayModel((int)mode.dmPelsWidth, (int)mode.dmPelsHeight, (int)mode.dmBitsPerPel);

            }

            throw new InvalidOperationException("EnumDisplaySettings()");
        }

        public SystemDisplayModel GetLowerDisplay()
        {
            var displays = GetAll();
            SystemDisplayModel lowerDislay = null;
            foreach (var display in displays)
            {
                if (lowerDislay == null || lowerDislay.Width > display.Width)
                {
                    lowerDislay = display;
                }
            }

            return lowerDislay;
        }

        public SystemDisplayModel GetHigherDisplay()
        {
            var displays = GetAll();
            SystemDisplayModel higherDislay = null;
            foreach (var display in displays)
            {
                if (higherDislay == null || higherDislay.Width < display.Width)
                {
                    higherDislay = display;
                }
            }

            return higherDislay;
        }

        public void SetCurrent(SystemDisplayModel display)
        {
            var originalMode = new NativeMethods.Display.DEVMODE();
            originalMode.dmSize = (ushort)Marshal.SizeOf(originalMode);

            NativeMethods.Display.EnumDisplaySettings(null, NativeMethods.Display.ENUM_CURRENT_SETTINGS, ref originalMode);

            var newMode = originalMode;
            newMode.dmPelsWidth = (uint)display.Width;
            newMode.dmPelsHeight = (uint)display.Height;
            newMode.dmBitsPerPel = (uint)display.BitCount;

            var result = NativeMethods.Display.ChangeDisplaySettings(ref newMode, 0);
            if (result == NativeMethods.Display.DISP_CHANGE_SUCCESSFUL)
            {
                return;
            }

            throw new InvalidOperationException("ChangeDisplaySettings()");
        }
    }
}
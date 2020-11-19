using Lib.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static Lib.Win32.NativeMethods;

namespace Lib.Win32
{
    public class SystemDisplayService : ISystemDisplayService
    {
        public List<DisplayModel> GetAll()
        {
            var modeIndex = 0;
            var mode = new Display.DEVMODE();
            var displays = new List<DisplayModel>();
            mode.dmSize = (ushort)Marshal.SizeOf(mode);

            while (Display.EnumDisplaySettings(null, modeIndex, ref mode))
            {
                var display = new DisplayModel((int)mode.dmPelsWidth, (int)mode.dmPelsHeight, (int)mode.dmBitsPerPel);
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

        public DisplayModel GetCurrent()
        {
            var mode = new Display.DEVMODE();
            mode.dmSize = (ushort)Marshal.SizeOf(mode);

            if (Display.EnumDisplaySettings(null, Display.ENUM_CURRENT_SETTINGS, ref mode))
            {
                return new DisplayModel((int)mode.dmPelsWidth, (int)mode.dmPelsHeight, (int)mode.dmBitsPerPel);

            }

            throw new InvalidOperationException("EnumDisplaySettings()");
        }

        public DisplayModel GetLowerDisplay()
        {
            var displays = GetAll();
            DisplayModel lowerDislay = null;
            foreach (var display in displays)
            {
                if (lowerDislay == null || lowerDislay.Width > display.Width)
                {
                    lowerDislay = display;
                }
            }

            return lowerDislay;
        }

        public DisplayModel GetHigherDisplay()
        {
            var displays = GetAll();
            DisplayModel higherDislay = null;
            foreach (var display in displays)
            {
                if (higherDislay == null || higherDislay.Width < display.Width)
                {
                    higherDislay = display;
                }
            }

            return higherDislay;
        }

        public void SetCurrent(DisplayModel display)
        {
            var originalMode = new Display.DEVMODE();
            originalMode.dmSize = (ushort)Marshal.SizeOf(originalMode);

            Display.EnumDisplaySettings(null, Display.ENUM_CURRENT_SETTINGS, ref originalMode);

            var newMode = originalMode;
            newMode.dmPelsWidth = (uint)display.Width;
            newMode.dmPelsHeight = (uint)display.Height;
            newMode.dmBitsPerPel = (uint)display.BitCount;

            var result = Display.ChangeDisplaySettings(ref newMode, 0);
            if (result == Display.DISP_CHANGE_SUCCESSFUL)
            {
                return;
            }

            throw new InvalidOperationException("ChangeDisplaySettings()");
        }
    }
}
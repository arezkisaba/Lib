using Lib.Core;

namespace Lib.Win32
{
    public class SystemSoundService : ISystemSoundService
    {
        public SystemSoundService()
        {
        }

        public void VolumeUp(int step)
        {
            for (var i = 0; i < step; i++)
            {
                NativeMethods.Keyboard.keybd_event(NativeMethods.Keyboard.VK_VOLUME_UP, 0, 0, 0);
            }
        }

        public void VolumeDown(int step)
        {
            for (var i = 0; i < step; i++)
            {
                NativeMethods.Keyboard.keybd_event(NativeMethods.Keyboard.VK_VOLUME_DOWN, 0, 0, 0);
            }
        }

        public void ToggleVolumeMute()
        {
            NativeMethods.Keyboard.keybd_event(NativeMethods.Keyboard.VK_VOLUME_MUTE, 0, 0, 0);
        }
    }
}
namespace Lib.Core
{
    public interface ISystemSoundService
    {
        void VolumeUp(int step);

        void VolumeDown(int step);

        void ToggleVolumeMute();
    }
}
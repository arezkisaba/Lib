namespace Lib.Core
{
    public interface ISystemSoundService
    {
        void VolumeUp(float soundStep = 0.05f);

        void VolumeDown(float soundStep = 0.05f);

        void ToggleMute();
    }
}
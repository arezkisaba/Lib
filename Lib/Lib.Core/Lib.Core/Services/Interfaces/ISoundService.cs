namespace Lib.Core
{
    public interface ISoundService
    {
        void Increase(float soundStep = 0.05f);

        void Decrease(float soundStep = 0.05f);

        void ToggleMute();
    }
}
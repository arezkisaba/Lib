using Lib.Core;
using NAudio.CoreAudioApi;
using System.Linq;

namespace Lib.Win32
{
    public class SoundService : ISoundService
    {
        private AudioEndpointVolume _audioEndpointVolume;

        public SoundService()
        {
            var enumerator = new MMDeviceEnumerator();
            var audioEndPoints = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            var mmDevice = audioEndPoints.FirstOrDefault();
            if (mmDevice != null)
            {
                _audioEndpointVolume = mmDevice.AudioEndpointVolume;
            }
        }

        public void Increase(float soundStep)
        {
            if (1 - _audioEndpointVolume.MasterVolumeLevelScalar < soundStep)
            {
                soundStep = 1 - _audioEndpointVolume.MasterVolumeLevelScalar;
            }

            _audioEndpointVolume.MasterVolumeLevelScalar += soundStep;
        }

        public void Decrease(float soundStep)
        {
            if (_audioEndpointVolume.MasterVolumeLevelScalar < soundStep)
            {
                soundStep = _audioEndpointVolume.MasterVolumeLevelScalar;
            }

            _audioEndpointVolume.MasterVolumeLevelScalar -= soundStep;
        }

        public void ToggleMute()
        {
            _audioEndpointVolume.Mute = !_audioEndpointVolume.Mute;
        }
    }
}
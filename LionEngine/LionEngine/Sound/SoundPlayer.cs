using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio;
using NAudio.Wave;
using NAudio.Mixer;

namespace LionEngine.LionEngine
{
    class SoundPlayer : IDisposable
    {
        IWavePlayer waveOutDevice;
        AudioFileReader audioFileReader;

        public bool isPlaying
        {
            get
            {
                return isPlaying;
            }

            set
            {
                if (value == false && value != isPlaying)
                {
                    Stop();
                } else if (value == true && value != isPlaying)
                {
                    Play();
                }
                isPlaying = value;
            }
        }

        public float Volume 
        {
            get
            {
                return Volume;
            }

            set
            {
                setVolume();
                Volume = value;
            }
        }

        public SoundPlayer(string directory)
        {
            waveOutDevice = new WaveOut();
            audioFileReader = new AudioFileReader(directory);
        }

        public SoundPlayer(AudioFileReader audioFileReader)
        {
            waveOutDevice = new WaveOut();
            this.audioFileReader = audioFileReader;
        }

        public void Play()
        {
            waveOutDevice.Init(audioFileReader);
            waveOutDevice.Play();
        }

        public void Stop()
        {
            waveOutDevice.Stop();
        }

        public void Pause()
        {
            waveOutDevice.Pause();
        }

        private void setVolume()
        {
            waveOutDevice.Volume = this.Volume;
        }

        public void Dispose()
        {
            waveOutDevice.Stop();
            audioFileReader.Dispose();
            waveOutDevice.Dispose();
        }
    }
}

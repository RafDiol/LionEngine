using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio;
using NAudio.Wave;

namespace LionEngine.LionEngine.Sound
{
    class SoundRecorder : IDisposable
    {
        WaveInEvent waveIn = new WaveInEvent();
        WaveFileWriter writer = null;

        public string outputLocation = null;
        public bool isRecording = false;
        public int? timeToRecord = null;

        public SoundRecorder()
        {
            AddHooks();
        }

        public SoundRecorder(string outputLocation)
        {
            this.outputLocation = outputLocation;
            AddHooks();
        }

        public SoundRecorder(string outputLocation, int timeToRecord)
        {
            this.outputLocation = outputLocation;
            this.timeToRecord = timeToRecord;
            AddHooks();
        }

        private void AddHooks()
        {
            waveIn.DataAvailable += (s, a) =>
            {
                writer.Write(a.Buffer, 0, a.BytesRecorded);
                if (timeToRecord != null)
                {
                    if (writer.Position > waveIn.WaveFormat.AverageBytesPerSecond * timeToRecord)
                    {
                        waveIn.StopRecording();
                        isRecording = false;
                    }
                }
            };
        }

        public void StartRecording()
        {
            if (outputLocation != null)
            {
                Directory.CreateDirectory(outputLocation);
                string output = Path.Combine(outputLocation, "recorder.wav");

                isRecording = true;

                writer = new WaveFileWriter(output, waveIn.WaveFormat);
                waveIn.StartRecording();
            }
            else
            {
                throw new ArgumentException("outputLocation must not be null");
            }
        }

        public void StopRecording()
        {
            waveIn.StopRecording();
            isRecording = false;
        }

        public void Dispose()
        {
            writer?.Dispose();
            writer = null;
            outputLocation = null;
            isRecording = false;
            timeToRecord = null;
            waveIn.Dispose();
        }
    }
}

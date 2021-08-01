using NAudio.Wave;

namespace SharpShooter_MM
{
    public class Sound
    {
        public WaveOutEvent waveOut;
        string file;
        public Sound(string file)
        {
            this.file = file;
            WaveFileReader wavReader = new WaveFileReader(file);
            this.waveOut = new WaveOutEvent();
            this.waveOut.Init(wavReader);
            this.waveOut.Volume = 0.2f;
        }

        public void Play()
        {
            WaveFileReader wavReader = new WaveFileReader(file);
            this.waveOut = new WaveOutEvent();
            this.waveOut.Init(wavReader);
            this.waveOut.Play();
            this.waveOut.PlaybackStopped += OnPlaybackStopped;
        }

        public void OnPlaybackStopped(object a, object b) //What are these?
        {
            this.waveOut.Dispose();
        }
    }
}
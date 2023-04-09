using System;

namespace BlazorAudioPlayerLib.Services.Notifies;

public class AudioPlayerNotify : IAudioPlayerNotify
{
    public event Action? OnMusicPlay;
    public event Action? OnMusicStop;

    public void MusicStarted()
    {
        OnMusicPlay?.Invoke();
    }

    public void MusicStopped()
    {
        OnMusicStop?.Invoke();
    }
}

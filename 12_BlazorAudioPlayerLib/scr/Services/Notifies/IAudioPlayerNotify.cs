using System;

namespace BlazorAudioPlayerLib.Services.Notifies;

public interface IAudioPlayerNotify
{
    event Action OnMusicPlay;
    event Action OnMusicStop;
    void MusicStarted();
    void MusicStopped();
}

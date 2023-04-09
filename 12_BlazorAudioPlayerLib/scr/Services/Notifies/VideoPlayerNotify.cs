
using System;
using System.Threading.Tasks;

namespace BlazorAudioPlayerLib.Services.Notifies;

public class VideoPlayerNotify : IVideoPlayerNotify
{
    public event Action? OnVideoPlay;
    public event Action? OnVideoStop;
    public event Func<Task>? OnVideoPlayAsync;
    public event Func<Task>? OnVideoStopAsync;

    public void VideoStarted()
    {
        OnVideoPlay?.Invoke();
        _ = OnVideoPlayAsync?.Invoke();
    }

    public void VideoStopped()
    {
        OnVideoStop?.Invoke();
        _ = OnVideoStopAsync?.Invoke();
    }   
}

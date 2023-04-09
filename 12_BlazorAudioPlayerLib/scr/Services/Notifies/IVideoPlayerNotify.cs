
using System;
using System.Threading.Tasks;

namespace BlazorAudioPlayerLib.Services.Notifies;

public interface IVideoPlayerNotify
{
    event Action OnVideoPlay;
    event Action OnVideoStop;
    event Func<Task> OnVideoPlayAsync;
    event Func<Task> OnVideoStopAsync;
    void VideoStarted();
    void VideoStopped();
}
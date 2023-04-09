
using System;
using System.Threading.Tasks;
using BlazorAudioPlayerLib.Services;
using BlazorAudioPlayerLib.Services.Notifies;
using Microsoft.AspNetCore.Components;

namespace BlazorAudioPlayerLib.Components.AudioPlayer;

public class AudioPlayerBase : ComponentBase, IDisposable
{
    [Inject]
    public IAudioPlayer AudioPlayer { get; set; }
    [Inject]
    public IVideoPlayerNotify VideoPlayerNotify { get; set; }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        VideoPlayerNotify.OnVideoPlayAsync += Stop;
        VideoPlayerNotify.OnVideoStopAsync += Play;
    }

    protected async Task Play()
    {
        await AudioPlayer.PlayMusic("music/IjomaTrack01.mp3");
    }

    protected async Task Stop()
    {
        await AudioPlayer.StopMusic("music/IjomaTrack01.mp3");
    }

    public void Dispose()
    {
        VideoPlayerNotify.OnVideoPlayAsync -= Stop;
        VideoPlayerNotify.OnVideoStopAsync -= Play;
    }
}
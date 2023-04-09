
using System.Threading.Tasks;
using BlazorAudioPlayerLib.Services.Notifies;
using Microsoft.AspNetCore.Components;

namespace BlazorAudioPlayerLib.Components.VideoPlayer;

public class VideoPlayerBase : ComponentBase
{
    private bool _isPlaying = false;

    [Inject]
    public IVideoPlayerNotify VideoPlayerNotify { get; init; }

    public ElementReference VideoPlayerRef { get; internal set; }

    [Parameter]
    public string? PlayerClass { get; set; } = string.Empty;

    [Parameter]
    public string? VideoPath { get; set; }



    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (firstRender)
        {
            StateHasChanged();
        }
    }


    internal void OnVideoPlay()
    {
        _isPlaying = true;

        VideoPlayerNotify.VideoStarted();
    }

    internal void OnVideoPause()
    {
        if (_isPlaying)
        {
            _isPlaying = false;

            VideoPlayerNotify.VideoStopped();
        }
    }
}
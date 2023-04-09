using System;
using System.Threading.Tasks;
using BlazorAudioPlayerLib.Interop;
using BlazorAudioPlayerLib.Services.Notifies;
using Microsoft.JSInterop;

namespace BlazorAudioPlayerLib.Services;

internal class HowlerPlayer : AudioJsInterop, IAudioPlayer
{
    private readonly IAudioPlayerNotify _notify;

    public HowlerPlayer(IJSRuntime jsRuntime, IAudioPlayerNotify notify)
        : base(jsRuntime)
    {
        _notify = notify;
    }

    public async Task PlayMusic(string audioFile)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("playMusic", audioFile);

        _notify.MusicStarted();
    }

    public async Task StopMusic(string audioFile)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("stopMusic", audioFile);

        _notify.MusicStopped();
    }
    public async Task PlayHover(string audioFile)
    {
        var module = await moduleTask.Value;
        var x = module;
        var xx = module;
        await module.InvokeVoidAsync("playHover", audioFile);
    }
    public async Task PlayClick(string audioFile)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("playClick", audioFile);
    }
}

using System.Threading.Tasks;
using BlazorAudioPlayerLib.Interop;
using Microsoft.JSInterop;

namespace BlazorAudioPlayerLib.Services;

internal class HowlerPlayer : AudioJsInterop, IAudioPlayer
{
    public HowlerPlayer(IJSRuntime jsRuntime) : base(jsRuntime)
    {

    }

    public async Task PlayMusic(string audioFile)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("playMusic", audioFile);
    }

    public async Task StopMusic(string audioFile)
    {
        var module = await moduleTask.Value;
        await module.InvokeVoidAsync("stopMusic", audioFile);
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

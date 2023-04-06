using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlazorAudioPlayerLib.Interop;

internal class AudioJsInterop : IAsyncDisposable
{
    protected readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public AudioJsInterop(IJSRuntime jsRuntime)
    {
        jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorAudioPlayerLib/js/howler.core.js");

        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorAudioPlayerLib/js/audioJsInterop.js").AsTask());
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}

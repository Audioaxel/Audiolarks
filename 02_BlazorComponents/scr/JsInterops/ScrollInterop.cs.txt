using Microsoft.JSInterop;

namespace BlazorComponents.Interop;

public class ScrollInterop : IAsyncDisposable
{
    protected readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public ScrollInterop(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./_content/BlazorComponents/js/scroll.js").AsTask());
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


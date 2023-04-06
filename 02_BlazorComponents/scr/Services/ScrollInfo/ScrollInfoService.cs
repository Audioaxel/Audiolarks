using System;
using Microsoft.JSInterop;

namespace BlazorComponents.Services.ScollInfo
{
    public class ScrollInfoService: IScrollInfoService
    {
        public event EventHandler<int> OnScroll; 

        public ScrollInfoService(IJSRuntime jsRuntime)
        {
            RegisterServiceViaJsRuntime(jsRuntime);
        }

        private void RegisterServiceViaJsRuntime(IJSRuntime jsRuntime)
        {
            jsRuntime.InvokeVoidAsync("RegisterScrollInfoService", DotNetObjectReference.Create(this));
        }

        public int YValue { get; private set; }

        [JSInvokable("OnScroll")]
        public void JsOnScroll(int yValue)
        {
            YValue = yValue;
            OnScroll?.Invoke(this, yValue);
        }
    }
}
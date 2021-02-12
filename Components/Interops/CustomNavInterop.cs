using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Components.Interops
{
    public class CustomNavInterop : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public CustomNavInterop(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/Components/js/CustomEventHandlers.js").AsTask());
        }

        public async ValueTask Initialize()
        {
            var module = await moduleTask.Value;

            await module.InvokeVoidAsync("customMouseEvents");
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
}

using Components.Interops;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Calendar.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var b = WebAssemblyHostBuilder.CreateDefault(args);
            b.RootComponents.Add<App>("#app");

            b.Services.AddHttpClient("Calendar.ServerAPI",
                client => client.BaseAddress = new Uri(b.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
           
            b.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Calendar.ServerAPI"));

            b.Services.AddApiAuthorization();

            b.Services.AddScoped<CustomNavInterop>();

            await b
                .Build()
                .RunAsync();
        }
    }
}

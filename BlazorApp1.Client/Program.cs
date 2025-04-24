using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Refit;

namespace BlazorApp1.Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var settings = new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer()
            };
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped(sp =>
                new HttpClient
                {
                    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
                });
            await builder.Build().RunAsync();
        }
    }
}

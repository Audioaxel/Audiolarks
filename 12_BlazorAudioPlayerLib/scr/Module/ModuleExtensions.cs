using BlazorAudioPlayerLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAudioPlayerLib.Module;
public static class ModuleExtensions
{
    public static void RegisterBlazorAudioPlayerLibServices(this IServiceCollection services)
    {
        services.AddScoped<IAudioPlayer, HowlerPlayer>();
    }

    public static void ConfigureBlazorAudioPlayerLib(this WebApplication app)
    {
 
    }
}

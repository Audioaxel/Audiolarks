using BlazorAudioPlayerLib.Services;
using BlazorAudioPlayerLib.Services.Notifies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorAudioPlayerLib.Module;
public static class ModuleExtensions
{
    public static void RegisterBlazorAudioPlayerLibServices(this IServiceCollection services)
    {
        services.AddScoped<IAudioPlayer, HowlerPlayer>();
        services.AddScoped<IAudioPlayerNotify, AudioPlayerNotify>();
        services.AddScoped<IVideoPlayerNotify, VideoPlayerNotify>();
    }

    public static void ConfigureBlazorAudioPlayerLib(this WebApplication app)
    {
 
    }
}

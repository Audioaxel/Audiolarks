using BlazorComponents.Services.ScollInfo;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorComponents.Module;

public static class ModuleExtensions
{
    public static void RegisterBlazorComponentsServices(this IServiceCollection services)
    {
        services.AddScoped<IScrollInfoService, ScrollInfoService>();
    }
}
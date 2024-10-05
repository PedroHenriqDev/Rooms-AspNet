using Microsoft.Extensions.DependencyInjection;
using Rooms.App.Services;
using Rooms.App.Services.Interfaces;

namespace Rooms.Shared.Ioc;

public static class AppDependencies
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        return services;
    }
}
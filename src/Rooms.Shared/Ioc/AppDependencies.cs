using Microsoft.Extensions.DependencyInjection;
using Rooms.App.Services;
using Rooms.App.Services.Interfaces;

namespace Rooms.Shared.Ioc;

public static class AppDependencies
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<IRoomTypeService, RoomTypeService>();
        services.AddScoped<IPersonService, PersonService>();
        services.AddScoped<ICryptoService, CryptoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IClaimService, ClaimService>();
        return services;
    }
}
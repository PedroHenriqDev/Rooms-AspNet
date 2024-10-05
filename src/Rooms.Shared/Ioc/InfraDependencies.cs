using System.Data;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Rooms.Domain.Repositories;
using Rooms.Infra.Repositories;

namespace Rooms.Shared.Ioc;

public static class ResolutionDependencies
{
    public static IServiceCollection AddInfra(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IDbConnection>(_ => 
        {
            return new SqlConnection(connectionString);
        });

        Assembly? myHandlers = AppDomain.CurrentDomain.Load("Rooms.Domain");
        services.AddMediatR(options => options.RegisterServicesFromAssemblies(myHandlers));

        return services;
    }
}
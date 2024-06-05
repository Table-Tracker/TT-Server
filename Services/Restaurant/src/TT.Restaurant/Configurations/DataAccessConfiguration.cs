using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TT.Restaurant.Infrastructure;

namespace TT.Restaurant.Configurations;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var databaseName = Environment.GetEnvironmentVariable("DATABASE");
        var databaseServer = Environment.GetEnvironmentVariable("Server");
        var databaseUid = Environment.GetEnvironmentVariable("UID");
        var databasePassword = Environment.GetEnvironmentVariable("PASSWORD");

        var connectionString = $"server={databaseServer};database={databaseName};uid={databaseUid};password={databasePassword}";

        var dbString = configuration.GetConnectionString(connectionString) ?? string.Empty;

        services.AddDbContext<RestaurantContext>(options => options.UseMySQL(dbString));

        return services;
    }
}

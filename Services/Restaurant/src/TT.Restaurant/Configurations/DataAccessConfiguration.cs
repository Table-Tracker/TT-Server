using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TT.Restaurant.Infrastructure;

namespace TT.Restaurant.Configurations;

public static class DataAccessConfiguration
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        var dbString = configuration.GetConnectionString("DbConnection") ?? string.Empty;

        services.AddDbContext<RestaurantContext>(options => options.UseMySQL(dbString));

        return services;
    }
}

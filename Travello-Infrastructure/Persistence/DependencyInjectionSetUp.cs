using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace Travello_Infrastructure.Persistence;

public static class DependencyInjectionSetUp
{
    public static void AddPersistence(
    this IServiceCollection services,
    IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<TravelloDbContext>(options =>
        {
            options.UseSqlServer(connectionString);
        });
    }
}

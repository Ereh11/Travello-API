using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

// using Microsoft.Extensions.Congiguration.Json;

namespace Travello_Infrastructure.Persistence
{
    public class TravelloDbContextFactory : IDesignTimeDbContextFactory<TravelloDbContext>
    {
        public TravelloDbContext CreateDbContext(string[] args)
        {
            // Point to the directory where appsettings.json resides
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), "../Travello");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePath) // Use the relative path to locate appsettings.json
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<TravelloDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            return new TravelloDbContext(optionsBuilder.Options);
        }
    }
}

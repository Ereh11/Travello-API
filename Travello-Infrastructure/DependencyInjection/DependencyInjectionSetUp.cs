using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Travello_Infrastructure.Cloudinary;
using Travello_Domain.Interfaces;
using Travello_Infrastructure.Persistence.Repository;
using Travello_Infrastructure.Persistence;

namespace Travello_Infrastructure.DependencyInjection;

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
        services.AddScoped<IImageRepository, CloudinaryImageService>();
        services.AddScoped<IHotelRepository, HotelRepository>();
        services.AddScoped<ILevelRepository, LevelRepository>();
        services.AddScoped<IOfferRepository, OfferRepository>();
        services.AddScoped<IPassportRepository, PassportRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserOfferRepository, UserOfferRepository>();
        services.AddScoped<IUserReviewRepository, UserReviewRepository>();
        services.AddScoped<IBookingRepository, BookingRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    public static void AddCloudinaryServices(this IServiceCollection services,
    IConfiguration configuration)
    {
        services.Configure<CloudinarySettings>(
            configuration.GetSection("CloudinarySettings")
        );
    }


}

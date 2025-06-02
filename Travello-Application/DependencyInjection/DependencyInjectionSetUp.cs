using Microsoft.Extensions.DependencyInjection;
using Travello_Application.Interfaces;
using Travello_Application.Services;

namespace Travello_Application.DependencyInjection;

public static class DependencyInjectionSetUp
{
    public static void AddApplicationServices(
    this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<IReviewService, ReviewService>();
    }
}

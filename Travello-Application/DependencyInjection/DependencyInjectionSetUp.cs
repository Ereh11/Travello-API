using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Travello_Application.Interfaces;
using Travello_Application.Services;
using Travello_Application.Validators;

namespace Travello_Application.DependencyInjection;

public static class DependencyInjectionSetUp
{
    public static void AddApplicationServices(
    this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IBookingService, BookingService>();
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IHotelImageService, HotelImageService>();
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjectionSetUp).Assembly
            );
    }
}

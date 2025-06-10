using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Travello_Application.Interfaces;
using Travello_Application.Services;
using Travello_Application.Validators;

namespace Travello_Application.DependencyInjection;

public static class DependencyInjectionSetUp
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IHotelService, HotelService>();
        services.AddScoped<IOfferService, OfferService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IBookingService, BookingService>();
<<<<<<< HEAD
        services.AddScoped<IAddressService, AddressService>();
        services.AddScoped<IHotelImageService, HotelImageService>();
        services.AddValidatorsFromAssembly(
            typeof(DependencyInjectionSetUp).Assembly
            );
=======
        services.AddScoped<AddHotelDtoValidator>();
>>>>>>> 9cdb45b0ec98b41c8219a91ab94a2f4921e9ca02
    }
}

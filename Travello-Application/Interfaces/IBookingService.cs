// using Travello_Application.Common.Result;
// using Travello_Application.Dtos.Booking;
// using Travello_Application.Interfaces;
// using Travello_Application.Validators;
using Travello_Application;
using Travello_Domain;
using Travello_Domain.Interfaces;

public interface IBookingService
{
    Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(Guid userId);
    // Task<BookingAvailabilityDto> CheckAvailabilityAsync(BookingAvailabilityDto dto);
    // Task ProcessRefundAsync(RefundRequestDto dto);
}

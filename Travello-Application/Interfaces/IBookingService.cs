using Travello_Application;
using Travello_Domain;
using Travello_Domain.Interfaces;

public interface IBookingService
{
    Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(
        Guid userId,
        BookingHistoryFilterDto? filter = null
    );

    // Task<BookingAvailabilityDto> CheckAvailabilityAsync(BookingAvailabilityDto dto);
    // Task ProcessRefundAsync(RefundRequestDto dto);
}

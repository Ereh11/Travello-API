using Travello_Application;

public interface IBookingService
{
    Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(
        Guid userId,
        BookingHistoryFilterDto? filter = null
    );
    Task CancelBookingAsync(Guid bookingId, string reason);
}

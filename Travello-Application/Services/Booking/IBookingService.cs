public interface IBookingService
{
    Task<BookingDetailsDto> CreateBookingAsync(CreateBookingDto dto, Guid userId);
    Task<IEnumerable<UserBookingHistoryDto>> GetUserHistoryAsync(Guid userId);
    Task<BookingAvailabilityDto> CheckAvailabilityAsync(BookingAvailabilityDto dto);
    Task ProcessRefundAsync(RefundRequestDto dto);
}

namespace Travello_Application;

public class UserBookingHistoryDto
{
    public Guid BookingId { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
    public string PaymentStatus { get; set; } = string.Empty;
    public string? RefundStatus { get; set; }
}

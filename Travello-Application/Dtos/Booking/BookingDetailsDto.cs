namespace Travello_Application;

public class BookingDetailsDto
{
    public Guid BookingId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
    public string HotelName { get; set; } = string.Empty;
    public int Stars { get; set; }
    public string HotelAddress { get; set; } = string.Empty;
    public string PaymentMethod { get; set; } = string.Empty;
    public DateTime? PaymentDate { get; set; }
    public string TransactionId { get; set; } = string.Empty;
    public string? RefundStatus { get; set; }
    public decimal? RefundAmount { get; set; }
    public string? RefundReason { get; set; }
}

namespace Travello_Application;

public class CreateBookingDto
{
    public Guid AccommodationId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public string PaymentMethod { get; set; } = string.Empty;
    public string? PaymentToken { get; set; }
    public string? PromoCode { get; set; }
}

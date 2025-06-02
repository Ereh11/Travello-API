namespace Travello_Application;

public class BookingAvailabilityDto
{
    public Guid HotelId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public bool IsAvailable { get; set; }
}

namespace Travello_Application;

public class RefundRequestDto
{
    public Guid BookingId { get; set; }
    public string Reason { get; set; } = string.Empty;
}

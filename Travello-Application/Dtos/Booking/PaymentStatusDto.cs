namespace Travello_Application;

public class PaymentStatusDto
{
    public Guid BookingId { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime? PaymentDate { get; set; }
    public string TransactionId { get; set; } = string.Empty;
}

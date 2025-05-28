using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Refund
{
    public Guid RefundId { get; set; }
    public Guid BookingId { get; set; }
    public decimal RefundPercentage { get; set; }
    public DateTime RefundDate { get; set; }
    public RefundStatus RefundStatus { get; set; } = RefundStatus.Pending;
    public string? Reason { get; set; } = string.Empty;
    public Booking Booking { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Booking
{
    public Guid BookingId { get; set; }
    public DateTime CheckInDate { get; set; }
    public DateTime CheckOutDate { get; set; }
    public int NumberOfGuests { get; set; }
    public decimal TotalPrice { get; set; }
    public Guid UserId { get; set; }
    public Guid HotelId { get; set; }
    public Guid PaymentId { get; set; }
    public User User { get; set; } = null!;
    public Hotel Hotel { get; set; } = null!;
    public Payment Payment { get; set; } = null!;
    public Refund? Refund { get; set; }
}

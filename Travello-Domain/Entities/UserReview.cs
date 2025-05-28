using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class UserReview
{
    public Guid UserId { get; set; }
    public User User { get; set; } = null!;
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public string Comment { get; set; } = string.Empty;
    public int Rating { get; set; }
}

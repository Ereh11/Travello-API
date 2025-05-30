using Travello_Domain;

namespace Travello_Application.Dtos.Review
{
    public class AddReviewDto
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; } = null!;
       d
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}

using Travello_Domain;


namespace Travello_Application.Dtos.Review
{
    public class AddReviewDto
    {
        public Guid UserId { get; set; }
        public Guid HotelId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}

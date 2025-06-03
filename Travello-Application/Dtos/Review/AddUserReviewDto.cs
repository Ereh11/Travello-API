using Travello_Domain;


namespace Travello_Application.Dtos.Review
{
    public class AddUserReviewDto
    {
        public Guid HotelId { get; set; }
        public string HotelName { get; set; } = string.Empty;

        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }

    }
}

namespace Travello_Application.Dtos.Review
{
    public class AddReviewDto
    {
        public Guid HotelId { get; set; }
        public string Comment { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}

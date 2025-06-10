namespace Travello_Domain;
public class Hotel
{
    public Guid HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stars { get; set; }
    public Guid AddressId { get; set; }
    public Address Address { get; set; } = null!;
    public ICollection<HotelImage> Images { get; set; } = new HashSet<HotelImage>();
    public ICollection<HotelFacility> HotelFacilities { get; set; } = new HashSet<HotelFacility>();
    public ICollection<UserReview> UserReviews { get; set; } = new HashSet<UserReview>();
    public ICollection<Accommodation> Accommodations { get; set; } = new HashSet<Accommodation>();
    public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
}

using Microsoft.AspNetCore.Identity;

namespace Travello_Domain
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public Guid? PassportId { get; set; }
        public Passport? Passport { get; set; } = null!;
        public Guid? ProfileImageId { get; set; }
        public Image? ProfileImage { get; set; } = null!;
        public Guid? AddressId { get; set; }
        public Address? Address { get; set; } = null!;
        public Guid LevelId { get; set; }
        public Level Level { get; set; } = null!;
        public ICollection<UserOffer> UserOffers { get; set; } = new HashSet<UserOffer>();
        public ICollection<UserReview> UserReviews { get; set; } = new HashSet<UserReview>();
        public ICollection<Booking> Bookings { get; set; } = new HashSet<Booking>();
    }
}

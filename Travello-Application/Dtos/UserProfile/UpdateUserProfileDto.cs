using Travello_Domain;

namespace Travello_Application.Dtos.UserProfile
{
    public class UpdateUserProfileDto
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Address? Address { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? LevelName { get; set; }
    }
}

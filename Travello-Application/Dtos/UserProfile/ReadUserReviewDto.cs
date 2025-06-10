using Travello_Application.Dtos.Address;
using Travello_Application.Dtos.Level;
using Travello_Application.Dtos.Passport;
using Travello_Domain;

namespace Travello_Application.Dtos.UserProfile
{
    public class ReadUserProfileDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; } = string.Empty;
        public LevelDto Level { get; set; }
        public AddPassportDto Passport { get; set; }
        public string ImageURL { get; set; } = string.Empty;
        public AddAddressDto Address { get; set; }

    }
}

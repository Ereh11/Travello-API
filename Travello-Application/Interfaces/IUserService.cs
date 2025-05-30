using Travello_Application.Dtos.Passport;
using Travello_Application.Dtos.UserProfile;

namespace Travello_Application.Interfaces
{
    public interface IUserService
    {
        Task<AddUserProfileDto> GetUserProfileAsync(Guid userId);
        Task UpdateUserProfileAsync(Guid userId, UpdateUserProfileDto dto);
        Task UpdatePassportAsync(Guid userId, UpdatePassportDto dto);
    }
}

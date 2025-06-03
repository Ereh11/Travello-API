using Microsoft.AspNetCore.Http;
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Passport;
using Travello_Application.Dtos.UserProfile;

namespace Travello_Application.Interfaces
{
    public interface IUserService
    {
        Task<GeneralResult<ReadUserProfileDto>> GetUserProfileAsync(Guid userId);
        Task<GeneralResult> UpdateUserProfileAsync(Guid userId, UpdateUserProfileDto dto);
        Task<GeneralResult> UpdatePassportAsync(Guid userId, UpdatePassportDto dto);
        Task<GeneralResult<string>> UpdateProfileImageAsync(Guid userId, IFormFile file);

    }
}

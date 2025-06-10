using Travello_Application.Common.Result;
using Travello_Application.Dtos.Review;
using Travello_Application.Dtos.UserProfile;
using Travello_Domain;

namespace Travello_Application.Interfaces
{
    public interface IReviewService
    {
        Task<GeneralResult> CreateReviewAsync(Guid userId, AddReviewDto dto);
        Task<GeneralResult<AddReviewDto>> GetReviewsByUserAsync(Guid userId);
    }
}

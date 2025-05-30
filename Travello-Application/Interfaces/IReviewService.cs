using Travello_Application.Dtos.Review;
using Travello_Domain;

namespace Travello_Application.Interfaces
{
    public interface IReviewService
    {
        Task CreateReviewAsync(Guid userId, AddReviewDto dto);
        Task<IEnumerable<UserReview>> GetReviewsByUserAsync(Guid userId);
    }
}

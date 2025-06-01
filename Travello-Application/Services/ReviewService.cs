using Travello_Application.Dtos.Review;
using Travello_Application.Interfaces;
using Travello_Domain;
using Travello_Domain.Interfaces;

public class ReviewService : IReviewService
{
    private readonly IUnitOfWork _unitOfWork;

    public ReviewService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task CreateReviewAsync(Guid userId, AddReviewDto dto)
    {
        if (await _unitOfWork.UserReviewRepository.ExistsAsync(userId, dto.HotelId))
            throw new Exception("Review already exists");

        var review = new UserReview
        {
            UserId = userId,
            HotelId = dto.HotelId,
            CreatedAt = DateTime.UtcNow,
            Comment = dto.Comment,
            Rating = dto.Rating
        };

        await _unitOfWork.UserReviewRepository.AddAsync(review);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<IEnumerable<UserReview>> GetReviewsByUserAsync(Guid userId)
    {
        return await _unitOfWork.UserReviewRepository.GetReviewsByUserIdAsync(userId);
    }
}
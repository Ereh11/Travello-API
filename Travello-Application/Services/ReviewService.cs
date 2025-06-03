using Travello_Application.Common.Result;
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


    public async Task<GeneralResult> CreateReviewAsync(Guid userId, AddReviewDto dto)
    {
        var review = new UserReview
        {
            UserId = userId,
            HotelId = dto.HotelId,
            Comment = dto.Comment,
            Rating = dto.Rating,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        await _unitOfWork.UserReviewRepository.AddAsync(review);
        await _unitOfWork.SaveChangesAsync();

        return new GeneralResult
        {
            Success = true,
            Message = "Review created successfully"
        };
    }

    public async Task<GeneralResult<AddReviewDto>> GetReviewsByUserAsync(Guid userId)
    {
        var reviews = await _unitOfWork.UserReviewRepository.GetReviewsByUserIdAsync(userId);

        var reviewDtos = reviews.Select(review => new AddReviewDto
        {
            HotelId = review.HotelId,
            Comment = review.Comment,
            Rating = review.Rating
        }).ToList();

        return new GeneralResult<AddReviewDto>
        {
            Success = true,
            Message = "User reviews retrieved successfully",
            Data = reviewDtos.FirstOrDefault() 
        };
    }
}
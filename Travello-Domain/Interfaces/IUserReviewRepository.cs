namespace Travello_Domain.Interfaces
{
    public interface IUserReviewRepository : IGenericRepository<UserReview>
    {
        Task<UserReview> GetByIdAsync(Guid userId, Guid hotelId);
        Task DeleteAsync(Guid userId, Guid hotelId);

        Task<IEnumerable<UserReview>> GetReviewsByUserIdAsync(Guid userId);
        Task<IEnumerable<UserReview>> GetReviewsByHotelIdAsync(Guid hotelId);
        Task<IEnumerable<UserReview>> GetReviewsByRatingAsync(int minRating, int maxRating);
        Task<double> GetAverageRatingForHotelAsync(Guid hotelId);
        Task<bool> ExistsAsync(Guid userId, Guid hotelId);

    }

}

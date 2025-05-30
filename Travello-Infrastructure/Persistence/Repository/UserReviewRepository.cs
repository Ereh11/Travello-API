using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class UserReviewRepository : GenericRepository<UserReview>, IUserReviewRepository
    {
        private readonly TravelloDbContext _context;
        public UserReviewRepository(TravelloDbContext context)
            : base(context)
        { }

        
        public async Task<double> GetAverageRatingForHotelAsync(Guid hotelId)
        {
            return await _context.UserReviews
                .Where(ur => ur.HotelId == hotelId)
                .AverageAsync(ur => (double?)ur.Rating) ?? 0.0;
        }

        public async Task<UserReview> GetByIdAsync(Guid userId, Guid hotelId)
        {
            return await _context.UserReviews
                .FirstOrDefaultAsync(ur => ur.UserId == userId && ur.HotelId == hotelId);
        }

        public async Task<IEnumerable<UserReview>> GetReviewsByHotelIdAsync(Guid hotelId)
        {
            return await _context.UserReviews
                .Where(ur => ur.HotelId == hotelId)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserReview>> GetReviewsByRatingAsync(int minRating, int maxRating)
        {
            return await _context.UserReviews
                .Where(ur => ur.Rating >= minRating && ur.Rating <= maxRating)
                .ToListAsync();
        }

        public async Task<IEnumerable<UserReview>> GetReviewsByUserIdAsync(Guid userId)
        {
            return await _context.UserReviews
                .Where(ur => ur.UserId == userId)
                .ToListAsync();
        }
        public async Task DeleteAsync(Guid userId, Guid hotelId)
        {
            await _context.UserReviews
               .Where(ur => ur.UserId == userId && ur.HotelId == hotelId)
               .ExecuteDeleteAsync();
        }

        public async Task<bool> ExistsAsync(Guid userId, Guid hotelId)
        {
            return await _context.UserReviews.AnyAsync(ur => ur.UserId == userId && ur.HotelId == hotelId);
        }

    }
}

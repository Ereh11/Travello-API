using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class UserOfferRepository : GenericRepository<UserOffer>, IUserOfferRepository
    {
        private readonly TravelloDbContext _context;
        public UserOfferRepository(TravelloDbContext context)
            : base(context)
        { }

       

        public async Task<IEnumerable<UserOffer>> GetActiveUserOffersAsync(Guid userId)
        {
            return await _context.UserOffers
                .Where(uo => uo.UserId == userId && uo.IsActive)
                .ToListAsync();
        }

        public async Task<UserOffer> GetByIdAsync(Guid userId, Guid offerId)
        {
            return await _context.UserOffers
                .FirstOrDefaultAsync( uo => uo.UserId == userId && uo.OfferId == offerId);
        }

        public async Task<IEnumerable<UserOffer>> GetUserOffersByOfferIdAsync(Guid offerId)
        {
            return await _context.UserOffers
                .Where(uo => uo.OfferId == offerId)
                .ToListAsync();
        }

        public async Task DeleteAsync(Guid userId, Guid offerId)
        {
             await _context.UserOffers
                .Where(uo => uo.UserId == userId && uo.OfferId == offerId)
                .ExecuteDeleteAsync();

        }

        public async Task<bool> ExistsAsync(Guid userId, Guid offerId)
        {
            return await _context.UserOffers.AnyAsync(uo => uo.UserId == userId && uo.OfferId == offerId);
        }

        public async Task<IEnumerable<UserOffer>> GetActiveOffersForUserAsync(Guid userId)
        {
            return await _context.UserOffers
                .Where(uo => uo.UserId == userId && uo.IsActive)
                .ToListAsync();

        }
    }
}

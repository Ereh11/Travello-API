using Microsoft.EntityFrameworkCore;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Infrastructure.Persistence.Repository
{
    public class OfferRepository : GenericRepository<Offer>, IOfferRepository
    {
        private readonly TravelloDbContext _context;
        public OfferRepository(TravelloDbContext context)
            : base(context)
        { }

        
        public async Task<IEnumerable<Offer>> GetActiveOffersAsync(DateTime currentDate)
        {
            return await _context.Offers
                .Where(o => o.StartDate <= currentDate && o.ExpiryDate >= currentDate)
                .ToListAsync();

        }

        public async Task<Offer> GetByPromoCodeAsync(string promoCode)
        {
            return await _context.Offers
                .FirstOrDefaultAsync(o => o.PromoCode == promoCode);

        }

        public async Task<IEnumerable<Offer>> GetOffersByDiscountRangeAsync(decimal minDiscount, decimal maxDiscount)
        {
            return await _context.Offers
                .Where(o => o.DiscountValue >= minDiscount && o.DiscountValue <= maxDiscount)
                .ToListAsync();
        }

        public async Task<bool> ExistsAsync(Guid offerId)
        {
            return await _context.Offers.AnyAsync(u => u.OfferId == offerId);
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersForUserAsync(Guid userId)
        {
            return await _context.Offers                           
                .Where(o => o.UserOffers.Any(uo => uo.UserId == userId) && o.StartDate <= DateTime.UtcNow && o.ExpiryDate >= DateTime.UtcNow)
                .ToListAsync();

        }
        public async Task<Offer?> GetOfferByIdAsync(Guid offerId, Guid userId)
        {
            return await _context.Offers
                .Include(o => o.UserOffers)
                .FirstOrDefaultAsync(o => o.OfferId == offerId && o.UserOffers.Any(uo => uo.UserId == userId));
        }
    }
}

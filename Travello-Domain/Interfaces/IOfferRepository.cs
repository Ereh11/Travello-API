namespace Travello_Domain.Interfaces
{
    public interface IOfferRepository : IGenericRepository<Offer>
    {
        // Specific Queries
        Task<Offer> GetByPromoCodeAsync(string promoCode);
        Task<IEnumerable<Offer>> GetActiveOffersAsync(DateTime currentDate);
        Task<IEnumerable<Offer>> GetOffersByDiscountRangeAsync(decimal minDiscount, decimal maxDiscount);
        Task<bool> ExistsAsync(Guid offerId);

    }
}

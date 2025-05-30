namespace Travello_Domain.Interfaces
{
    public interface IUserOfferRepository : IGenericRepository<UserOffer>
    {
        Task<UserOffer> GetByIdAsync(Guid userId, Guid offerId);
        Task DeleteAsync(Guid userId, Guid offerId);

        // Specific Queries
        Task<IEnumerable<UserOffer>> GetActiveUserOffersAsync(Guid userId);
        Task<IEnumerable<UserOffer>> GetUserOffersByOfferIdAsync(Guid offerId);
        Task<bool> ExistsAsync(Guid userId, Guid offerId);


    }
}

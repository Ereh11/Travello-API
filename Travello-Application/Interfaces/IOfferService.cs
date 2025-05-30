using Travello_Domain;

namespace Travello_Application.Interfaces
{
    public interface IOfferService
    {
        Task ActivateOfferAsync(Guid userId, Guid offerId);
        Task<IEnumerable<Offer>> GetActiveOffersForUserAsync(Guid userId);
    }
}

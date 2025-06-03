using Travello_Application.Common.Result;
using Travello_Application.Dtos.Offer;

namespace Travello_Application.Interfaces
{
    public interface IOfferService
    {
        Task<GeneralResult<IEnumerable<OfferDto>>> GetActiveOffersForUserAsync(Guid userId);
        Task<GeneralResult> ActivateOfferAsync(Guid userId, Guid offerId);

    }
}

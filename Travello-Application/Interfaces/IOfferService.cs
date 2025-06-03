using Travello_Application.Common.Result;
using Travello_Application.Dtos.Offer;
using Travello_Application.Dtos.UesrOffer;

namespace Travello_Application.Interfaces
{
    public interface IOfferService
    {
        Task<GeneralResult<IEnumerable<UserOfferDto>>> GetActiveOffersForUserAsync(Guid userId);
        Task<GeneralResult> ActivateOfferAsync(Guid userId, Guid offerId);

    }
}

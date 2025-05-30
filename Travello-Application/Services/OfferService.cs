using Travello_Application.Interfaces;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task ActivateOfferAsync(Guid userId, Guid offerId)
        {
            if (!await _unitOfWork.OfferRepository.ExistsAsync(offerId))
                throw new Exception("Offer not found");

            var userOffer = new UserOffer
            {
                UserId = userId,
                OfferId = offerId,
                DateOfActivate = DateTime.UtcNow,
                IsActive = true
            };

            await _unitOfWork.UserOfferRepository.AddAsync(userOffer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Offer>> GetActiveOffersForUserAsync(Guid userId)
        {
            var userOffers = await _unitOfWork.UserOfferRepository.GetActiveUserOffersAsync(userId);
            return userOffers.Select(uo => uo.Offer);
        }
    }
}

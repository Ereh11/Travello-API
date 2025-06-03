
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Offer;
using Travello_Application.Interfaces;
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

        public async Task<GeneralResult<IEnumerable<OfferDto>>> GetActiveOffersForUserAsync(Guid userId)
        {
            var offers = await _unitOfWork.OfferRepository.GetActiveOffersForUserAsync(userId);

            var offerDtos = offers.Select(o => new OfferDto
            {
                Title = o.Title,
                DiscountValue = o.DiscountValue,
                PromoCode = o.PromoCode,
                StartDate = o.StartDate,
                ExpiryDate = o.ExpiryDate,
                DateOfActivate = o.DateOfActivate
            }).ToList();

            return new GeneralResult<IEnumerable<OfferDto>>
            {
                Success = true,
                Message = "Active offers retrieved successfully",
                Data = offerDtos
            };
        }

        public async Task<GeneralResult> ActivateOfferAsync(Guid userId, Guid offerId)
        {
            var offer = await _unitOfWork.OfferRepository.GetOfferByIdAsync(offerId, userId);

            if (offer == null)
            {
                return new GeneralResult
                {
                    Success = false,
                    Message = "Offer not found or not associated with user"
                };
            }

            offer.DateOfActivate = DateTime.UtcNow;
            await _unitOfWork.OfferRepository.AddAsync(offer);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Message = "Offer activated successfully"
            };
        }
    }
}
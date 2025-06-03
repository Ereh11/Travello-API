
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Offer;
using Travello_Application.Dtos.UesrOffer;
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

        public async Task<GeneralResult<IEnumerable<UserOfferDto>>> GetActiveOffersForUserAsync(Guid userId)
        {
            var offers = await _unitOfWork.UserOfferRepository.GetActiveOffersForUserAsync(userId);

            var offerDtos = offers.Select(o => new UserOfferDto
            {
                UserId = o.UserId,
                OfferId = o.OfferId,
                DateOfActivate = o.DateOfActivate,
                IsActive = o.IsActive

            }).ToList();

            return new GeneralResult<IEnumerable<UserOfferDto>>
            {
                Success = true,
                Message = "Active offers retrieved successfully",
                Data = offerDtos
            };
        }

        public async Task<GeneralResult> ActivateOfferAsync(Guid userId, Guid offerId)
        {
            var offer = await _unitOfWork.UserOfferRepository.GetByIdAsync(offerId, userId);

            if (offer == null)
            {
                return new GeneralResult
                {
                    Success = false,
                    Message = "Offer not found or not associated with user"
                };
            }

            offer.DateOfActivate = DateTime.UtcNow;
            await _unitOfWork.UserOfferRepository.AddAsync(offer);
            await _unitOfWork.SaveChangesAsync();

            return new GeneralResult
            {
                Success = true,
                Message = "Offer activated successfully"
            };
        }

       
    }
}
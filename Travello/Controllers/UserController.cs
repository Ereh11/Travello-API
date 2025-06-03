using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Offer;
using Travello_Application.Dtos.Passport;
using Travello_Application.Dtos.Review;
using Travello_Application.Dtos.UserProfile;
using Travello_Application.Interfaces;
using Travello_Domain.Interfaces;

namespace Travello.Controllers
{
    [Route("api/users/{userId}")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IReviewService _reviewService;
        private readonly IOfferService _offerService;
        private readonly IImageRepository _imageRepository;
        public UserController(IUserService userService, IReviewService reviewService, IOfferService offerService, IImageRepository imageRepository)
        {
            _userService = userService;
            _reviewService = reviewService;
            _offerService = offerService;
            _imageRepository = imageRepository;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<GeneralResult<AddUserProfileDto>>> GetUserProfile(Guid userId)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _userService.GetUserProfileAsync(userId);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpPut("profile")]
        public async Task<ActionResult<GeneralResult>> UpdateUserProfile(Guid userId, [FromBody] UpdateUserProfileDto dto)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _userService.UpdateUserProfileAsync(userId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }


        [HttpPut("passport")]
        public async Task<ActionResult<GeneralResult>> UpdatePassport(Guid userId, [FromBody] UpdatePassportDto dto)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _userService.UpdatePassportAsync(userId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("profile-image")]
        public async Task<ActionResult<GeneralResult<string>>> UploadProfileImage(Guid userId, IFormFile file)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            try
            {
                //var imageUrl = await _imageRepository.UploadImageAsync(userId, file);
                return Ok(new GeneralResult<string>
                {
                    Success = true,
                    Message = "Profile image uploaded successfully",
                    //Data = imageUrl
                });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new GeneralResult { Success = false, Message = ex.Message });
            }
        }
        [HttpGet("reviews")]
        public async Task<ActionResult<GeneralResult<IEnumerable<AddReviewDto>>>> GetUserReviews(Guid userId)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _reviewService.GetReviewsByUserAsync(userId);
            return result.Success ? Ok(result) : NotFound(result);
        }
        [HttpPost("reviews")]
        public async Task<ActionResult<GeneralResult>> CreateReview(Guid userId, [FromBody] AddReviewDto dto)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _reviewService.CreateReviewAsync(userId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("offers")]
        public async Task<ActionResult<GeneralResult<IEnumerable<OfferDto>>>> GetUserOffers(Guid userId)
        {
            //if (!IsAuthorizedUser(userId))
            //    return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _offerService.GetActiveOffersForUserAsync(userId);
            return result.Success ? Ok(result) : NotFound(result);
        }


        [HttpPost("offers/{offerId}/activate")]
        public async Task<ActionResult<GeneralResult>> ActivateOffer(Guid userId, Guid offerId)
        {
            if (!IsAuthorizedUser(userId))
                return Unauthorized(new GeneralResult { Success = false, Message = "Unauthorized access" });

            var result = await _offerService.ActivateOfferAsync(userId, offerId);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        private bool IsAuthorizedUser(Guid userId)
        {
            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return currentUserId != null && Guid.Parse(currentUserId) == userId;
        }
    }

}


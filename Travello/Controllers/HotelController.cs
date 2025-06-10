using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Dtos.Hotel;
using Travello_Application.Interfaces;
using Travello_Application.Services;

namespace Travello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _hotelService;
        private readonly IHotelImageService _hotelImageService;
        public HotelController(IHotelService hotelService,
            IHotelImageService hotelImageService
            )
        {
            _hotelService = hotelService;
            _hotelImageService = hotelImageService;

        }
        [HttpPost]
        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> AddHotel([FromBody] AddHotelDto addHotelDto)
        {
            var reponse = await _hotelService.AddHotelAsync(addHotelDto);
            if (reponse.Success)
            {
                return TypedResults.Ok(reponse);
            }
            return TypedResults.BadRequest(reponse);
        }
        [HttpGet("{id:guid}")]

        public async Task<Results<Ok<GeneralResult<ViewHotelDto?>>, NotFound<GeneralResult<ViewHotelDto?>>>> GetHotelById(Guid id)
        {
            var response = await _hotelService.GetHotelByIdAsync(id);
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.NotFound(response);
        }
        [HttpGet]
        public async Task<Results<Ok<GeneralResult<List<ViewHotelDto>?>>, NotFound<GeneralResult<List<ViewHotelDto>?>>>> GetAllHotels()
        {
            var response = await _hotelService.GetAllHotelsAsync();
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.NotFound(response);
        }
        [HttpPost("{id:guid}/images")]
        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> UploadHotelImage([FromForm] UploadHotelImageDto uploadHotelImageDto, Guid id)
        {
            var response = await _hotelImageService
                .UploadHotelImageAsync(uploadHotelImageDto, id);
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.BadRequest(response);
        }

    }
}

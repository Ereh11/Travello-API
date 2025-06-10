using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Interfaces;

namespace Travello.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }
        [HttpPost]
        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> AddAddress([FromBody] AddAddressDto addAddressDto)
        {
            var response = await _addressService.AddAddressAsync(addAddressDto);
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.BadRequest(response);
        }
        [HttpGet]
        public async Task<Results<Ok<GeneralResult<List<ViewAddressDto>?>>, NotFound<GeneralResult<List<ViewAddressDto>?>>>> GetAllAddresses()
        {
            var response = await _addressService.GetAllAddressesAsync();
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.NotFound(response);
        }
        [HttpPut("{id:Guid}")]

        public async Task<Results<Ok<GeneralResult>, BadRequest<GeneralResult>>> UpdateAddress(Guid id, [FromBody] UpdateAddressDto updateAddressDto)
        {
            var response = await _addressService.UpdateAddressAsync(id, updateAddressDto);
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.BadRequest(response);
        }
        [HttpDelete("{id:Guid}")]
        public async Task<Results<Ok<GeneralResult>, NotFound<GeneralResult>>> DeleteAddress(Guid id)
        {
            var response = await _addressService.DeleteAddressAsync(id);
            if (response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.NotFound(response);
        }
        [HttpGet("{id:Guid}")]
        public async Task<Results<Ok<GeneralResult<ViewAddressDto>>, NotFound<GeneralResult<ViewAddressDto>>>> GetAddressById(Guid id)
        {
            var response = await _addressService.GetAddressByIdAsync(id);
            if (response != null && response.Success)
            {
                return TypedResults.Ok(response);
            }
            return TypedResults.NotFound(response);
        }
    }
}

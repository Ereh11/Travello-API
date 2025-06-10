using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Dtos.Hotel;

namespace Travello_Application.Interfaces
{
    public interface IHotelService
    {
        Task<GeneralResult> AddHotelAsync(AddHotelDto addHotelDto);
        Task<GeneralResult<ViewHotelDto?>> GetHotelByIdAsync(Guid id);
        Task<GeneralResult<List<ViewHotelDto>?>> GetAllHotelsAsync();
    }
}

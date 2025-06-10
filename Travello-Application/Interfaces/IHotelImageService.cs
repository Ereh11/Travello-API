using Travello_Application.Common.Result;
using Travello_Application.Dtos;

namespace Travello_Application.Interfaces
{
    public interface IHotelImageService
    {
        Task<GeneralResult> UploadHotelImageAsync(UploadHotelImageDto uploadHotelImageDto, Guid HotelId);
        Task<GeneralResult> DeleteImgeAsync(Guid imgeId);
    }
}

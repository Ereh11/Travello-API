using Microsoft.AspNetCore.Http;

namespace Travello_Application.Dtos;

public class UploadHotelImageDto
{
    public IFormFile File { get; set; } = null!;
}

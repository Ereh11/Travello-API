
namespace Travello_Application.Dtos;

public class AddHotelImageDto
{
    public string ImgeURL { get; set; } = string.Empty;
    public Guid HotelId { get; set; } = Guid.Empty;
}

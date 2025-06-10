
namespace Travello_Application.Dtos;

public class ViewHotelDto
{
    public Guid HotelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stars { get; set; }
    public ViewAddressDto Address { get; set; } = null!;
    public List<ViewHotelImageForHotelDto>? Images { get; set; } = null!;

}

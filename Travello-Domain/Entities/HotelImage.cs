
namespace Travello_Domain;

public class HotelImage
{
    public Guid ImageId { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
}

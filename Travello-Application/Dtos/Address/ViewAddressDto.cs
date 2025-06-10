namespace Travello_Application.Dtos;
public class ViewAddressDto
{
    public Guid AddressId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Application.Dtos.Hotel;

public class AddHotelDto
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stars { get; set; }
    public Guid AddressId { get; set; }
    public Guid? ImageId { get; set; }
}

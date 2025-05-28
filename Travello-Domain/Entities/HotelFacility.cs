using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class HotelFacility
{
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;
    public Guid FacilityId { get; set; }
    public Facility Facility { get; set; } = null!;
}

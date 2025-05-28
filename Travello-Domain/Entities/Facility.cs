using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Facility
{
    public Guid FacilityId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool IsFree { get; set; }
    public decimal? Price { get; set; }
    public ICollection<HotelFacility> HotelFacilities { get; set; } = new HashSet<HotelFacility>();
}

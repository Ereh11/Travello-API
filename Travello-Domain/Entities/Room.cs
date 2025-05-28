using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Room
{
    public Guid RoomId { get; set; }
    public RoomType RoomType { get; set; }
    public BathroomType BathroomType { get; set; }
    public BedConfiguration BedConfiguration { get; set; }
    public Guid AccommodationId { get; set; }
    public Accommodation Accommodation { get; set; } = null!;

}

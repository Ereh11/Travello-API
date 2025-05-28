using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Accommodation
{
    public Guid AccommodationId { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public AccommodationType AccommodationType { get; set; }
    public AccommodationView AccommodationView { get; set; }
    public int NumberOfRooms { get; set; }
    public int NumberOfBathroom { get; set; }
    public int Capacity { get; set; }
    public Guid HotelId { get; set; }
    public Hotel Hotel { get; set; } = null!;

    public ICollection<Room> Rooms { get; set; } = new HashSet<Room>();
}

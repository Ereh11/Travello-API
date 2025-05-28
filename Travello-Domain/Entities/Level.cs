using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Level
{
    public Guid LevelId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal DiscountPercentage { get; set; }
    public bool IsFreeTransportation { get; set; } 
    public ICollection<User> Users { get; set; } = new HashSet<User>();
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class UserOffer
{
    public Guid UserId { get; set; }
    public Guid OfferId { get; set; }
    public DateTime DateOfActivate { get; set; }
    public bool IsActive { get; set; } = true;
    public User User { get; set; } = null!;
    public Offer Offer { get; set; } = null!;
}

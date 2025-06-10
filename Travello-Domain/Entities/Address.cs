using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travello_Domain;

public class Address
{
    public Guid AddressId { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
<<<<<<< HEAD
    public string Street { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
=======
    public string Government { get; set; } = string.Empty;
    public string State { get; set; } = string.Empty;
>>>>>>> 9cdb45b0ec98b41c8219a91ab94a2f4921e9ca02
}

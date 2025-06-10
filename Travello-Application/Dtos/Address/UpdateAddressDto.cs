<<<<<<< HEAD
﻿namespace Travello_Application.Dtos;

public class UpdateAddressDto
{
    public string City { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public string ZipCode { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string Governorate { get; set; } = string.Empty;
=======
﻿namespace Travello_Application.Dtos.Address
{
    public class UpdateAddressDto
    {
        public Guid AddressID { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
>>>>>>> 9cdb45b0ec98b41c8219a91ab94a2f4921e9ca02
}

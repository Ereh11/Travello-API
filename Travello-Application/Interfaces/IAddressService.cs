using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Common.Result;
using Travello_Application.Dtos;

namespace Travello_Application.Interfaces;

public interface IAddressService
{
    Task<GeneralResult> AddAddressAsync(AddAddressDto addAddressDto);
    Task<GeneralResult> UpdateAddressAsync(Guid addressId, UpdateAddressDto updateAddressDto);
    Task<GeneralResult> DeleteAddressAsync(Guid addressId);
    Task<GeneralResult<ViewAddressDto>?> GetAddressByIdAsync(Guid addressId);
    Task<GeneralResult<List<ViewAddressDto>?>> GetAllAddressesAsync();
}

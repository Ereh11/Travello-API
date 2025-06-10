using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Interfaces;
using Travello_Application.Validators;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services;

public class AddressService : IAddressService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AddAddressDtoValidator _validationRules;
    private readonly UpdateAddressDtoValidator _updateValidationRules;
    public AddressService(IUnitOfWork unitOfWork,
        AddAddressDtoValidator validationRules,
        UpdateAddressDtoValidator updateValidationRules)
    {
        _unitOfWork = unitOfWork;
        _validationRules = validationRules;
        _updateValidationRules = updateValidationRules;
    }
    public async Task<GeneralResult> AddAddressAsync(AddAddressDto addAddressDto)
    {
        var validationResult = await _validationRules
            .ValidateAsync(addAddressDto);
        if (!validationResult.IsValid)
        {
            return validationResult.MapErrorToGeneralResult();
        }
        var address = new Address
        {
            Street = addAddressDto.Street,
            City = addAddressDto.City,
            Country = addAddressDto.Country,
            Governorate = addAddressDto.Governorate,
            ZipCode = addAddressDto.ZipCode
        };
        await _unitOfWork.AddressRepository
            .AddAsync(address);
        await _unitOfWork.SaveChangesAsync();
        return GeneralResult.MappingSuccessResult("Address added successfully");
    }

    public async Task<GeneralResult> DeleteAddressAsync(Guid addressId)
    {
        var address = await _unitOfWork.AddressRepository
            .GetByIdAsync(addressId);
        if (address == null)
        {
            return GeneralResult.MappingErrorResult("Address not found",
                [new ResultError { Message = "Address not found", Code = "404" }]);
        }
        await _unitOfWork.AddressRepository.DeleteAsync(addressId);
        await _unitOfWork.SaveChangesAsync();
        return GeneralResult.MappingSuccessResult("Address deleted successfully");
    }

    public async Task<GeneralResult<ViewAddressDto>?> GetAddressByIdAsync(Guid addressId)
    {
        var address = await _unitOfWork.AddressRepository
            .GetByIdAsync(addressId);
        if (address == null)
        {
            return GeneralResult<ViewAddressDto>.MappingErrorResult("Address not found",
                    [ new ResultError { Message = "Address not found", Code = "404" } 
                    ]);
        }
        return GeneralResult<ViewAddressDto>.MappingSuccessResult(
            new ViewAddressDto
            {
                AddressId = address.AddressId,
                Street = address.Street,
                City = address.City,
                Country = address.Country,
                Governorate = address.Governorate,
                ZipCode = address.ZipCode
            }, "Address retrieved successfully");
    }

    public async Task<GeneralResult<List<ViewAddressDto>?>> GetAllAddressesAsync()
    {
        var addresses = await _unitOfWork.AddressRepository
            .GetAllAsync();
        if (addresses == null || !addresses.Any())
        {
            return GeneralResult<List<ViewAddressDto>?>.MappingErrorResult("No addresses found",
                [new ResultError { Message = "No addresses found", Code = "404" }]);
        }
        var viewAddresses = addresses.Select(a => new ViewAddressDto
        {
            AddressId = a.AddressId,
            Street = a.Street,
            City = a.City,
            Country = a.Country,
            Governorate = a.Governorate,
            ZipCode = a.ZipCode
        }).ToList();
        return GeneralResult<List<ViewAddressDto>?>.MappingSuccessResult(viewAddresses,
            "Addresses retrieved successfully");
    }

    public async Task<GeneralResult> UpdateAddressAsync(Guid addressId, UpdateAddressDto updateAddressDto)
    {
        var validationResult = await _updateValidationRules
            .ValidateAsync(updateAddressDto);
        if (!validationResult.IsValid)
        {
            return validationResult.MapErrorToGeneralResult();
        }
        var address = await _unitOfWork.AddressRepository
            .GetByIdAsync(addressId);
        if (address == null)
        {
            return GeneralResult.MappingErrorResult("Address not found",
                [new ResultError { Message = "Address not found", Code = "404" }]);
        }
        address.Street = updateAddressDto.Street;
        address.City = updateAddressDto.City;
        address.Country = updateAddressDto.Country;
        address.Governorate = updateAddressDto.Governorate;
        address.ZipCode = updateAddressDto.ZipCode;
        _unitOfWork.AddressRepository.Update(address);
        await _unitOfWork.SaveChangesAsync();
        return GeneralResult.MappingSuccessResult("Address updated successfully");
    }
}

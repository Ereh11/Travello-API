using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Dtos.Hotel;
using Travello_Application.Interfaces;
using Travello_Application.Validators;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services;

public class HotelService : IHotelService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly AddHotelDtoValidator _validationRules;
    public HotelService(IUnitOfWork unitOfWork,
        AddHotelDtoValidator validationRules
        )
    {
        _unitOfWork = unitOfWork;
        _validationRules = validationRules;
    }
    public async Task<GeneralResult> AddHotelAsync(AddHotelDto addHotelDto)
    {

        var validationResult = await _validationRules.ValidateAsync(addHotelDto);
        if (!validationResult.IsValid)
        {
            return validationResult.MapErrorToGeneralResult();
        }
        var hotel = new Hotel
        {
            Name = addHotelDto.Name,
            Description = addHotelDto.Description,
            Stars = addHotelDto.Stars,
            AddressId = addHotelDto.AddressId,
        };

        await _unitOfWork.HotelRepository.AddAsync(hotel);
        await _unitOfWork.SaveChangesAsync();

        return GeneralResult.MappingSuccessResult("Hotel added successfully");
    }

    public async Task<GeneralResult<List<ViewHotelDto>?>> GetAllHotelsAsync()
    {
        var hotels = await _unitOfWork.HotelRepository
            .GetAllHotelsWithAllDetailsAsync();
        if (hotels == null || !hotels.Any())
        {
            return GeneralResult<List<ViewHotelDto>?>.MappingErrorResult("No hotels found");
        }
        var viewHotels = hotels.Select(h => new ViewHotelDto
        {
            HotelId = h.HotelId,
            Name = h.Name,
            Description = h.Description,
            Stars = h.Stars,
            Address = new ViewAddressDto
            {
                AddressId = h.Address.AddressId,
                Street = h.Address.Street,
                City = h.Address.City,
                Country = h.Address.Country,
                ZipCode = h.Address.ZipCode,
                Governorate = h.Address.Governorate
            },
            Images = h.Images.Select(i => new ViewHotelImageForHotelDto
            {
                ImageURL = i.ImageURL,
            }).ToList()
        }).ToList();
        return GeneralResult<List<ViewHotelDto>?>.MappingSuccessResult(viewHotels, "Data is retrived successfully!");
    }

    public async Task<GeneralResult<ViewHotelDto?>> GetHotelByIdAsync(Guid id)
    {
       var hotel = await _unitOfWork.HotelRepository
            .GetHotelWithAllDetailsAsync(id);
        if (hotel == null)
        {
            return GeneralResult<ViewHotelDto?>.MappingErrorResult("Hotel not found");
        }
        var viewHotelDto = new ViewHotelDto
        {
            HotelId = hotel.HotelId,
            Name = hotel.Name,
            Description = hotel.Description,
            Stars = hotel.Stars,
            Address = new ViewAddressDto
            {
                AddressId = hotel.Address.AddressId,
                Street = hotel.Address.Street,
                City = hotel.Address.City,
                Country = hotel.Address.Country,
                ZipCode = hotel.Address.ZipCode,
                Governorate = hotel.Address.Governorate
            }
        };
        return GeneralResult<ViewHotelDto?>.MappingSuccessResult(viewHotelDto, "Data is retrived successfully!");
    }
}

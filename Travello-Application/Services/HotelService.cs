using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Common.Result;
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
    public async Task<GeneralResult> AddHotel(AddHotelDto addHotelDto)
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
        };

        await _unitOfWork.HotelRepository.AddAsync(hotel);
        await _unitOfWork.SaveChangesAsync();

        return GeneralResult.MappingSuccessResult("Hotel added successfully");
    }
}

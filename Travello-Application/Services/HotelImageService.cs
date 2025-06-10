using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Common.Result;
using Travello_Application.Dtos;
using Travello_Application.Interfaces;
using Travello_Application.Validators;
using Travello_Domain;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services;

public class HotelImageService : IHotelImageService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly UploadHotelImageDtoValidator _uploadHotelImageDtoValidator;
    public HotelImageService(IUnitOfWork unitOfWork,
        UploadHotelImageDtoValidator updateAddressDtoValidator
        )
    {
        _unitOfWork = unitOfWork;
        _uploadHotelImageDtoValidator = updateAddressDtoValidator;
    }
    public Task<GeneralResult> DeleteImgeAsync(Guid imgeId)
    {
        throw new NotImplementedException();
    }

    public async Task<GeneralResult> UploadHotelImageAsync(UploadHotelImageDto uploadHotelImageDto, Guid HotelId)
    {
        var validationResult = await _uploadHotelImageDtoValidator
            .ValidateAsync(uploadHotelImageDto);
        if (!validationResult.IsValid)
        {
            return validationResult.MapErrorToGeneralResult();
        }
        string imageURL = await _unitOfWork.Attachment
            .UploadAsync(uploadHotelImageDto.File);
        if(imageURL == "Image upload failed")
            return GeneralResult.MappingErrorResult("Image upload failed. there is an error with the service provider.");
        var addHotelImage = new HotelImage
        {
            ImageURL = imageURL,
            HotelId = HotelId,
        };
        await _unitOfWork.HotelImageRepository
            .AddImageAsync(addHotelImage);
        await _unitOfWork.SaveChangesAsync();
        return GeneralResult<string>.MappingSuccessResult(imageURL, "Image is uploaded successfully");
        
    }

}

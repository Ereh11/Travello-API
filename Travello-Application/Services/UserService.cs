
using Microsoft.AspNetCore.Http;
using Travello_Application.Common.Result;
using Travello_Application.Dtos.Address;
using Travello_Application.Dtos.Level;
using Travello_Application.Dtos.Passport;
using Travello_Application.Dtos.UserProfile;
using Travello_Application.Interfaces;
using Travello_Domain.Interfaces;

namespace Travello_Application.Services
{
public class UserService : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<GeneralResult<ReadUserProfileDto>> GetUserProfileAsync(Guid userId)
    {
        var user = await _unitOfWork.UserRepository.GetUserWithDetailsAsync(userId);
        if (user == null )
            {
                return new GeneralResult<ReadUserProfileDto>
                {
                    Success = false,
                    Message = "User profile not found"
                };
            }

        var profileDto = new ReadUserProfileDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Gender = user.Gender,
            DateOfBirth = user.DateOfBirth,
            Nationality = user.Nationality,
            Email = user.Email,
            ImageURL = user.ProfileImage?.ImageURL,
            Level = new LevelDto
            {
                Name = user.Level.Name,
                Description = user.Level.Description,
                DiscountPercentage = user.Level.DiscountPercentage,
                IsFreeTransportation = user.Level.IsFreeTransportation
            },
            Passport = new AddPassportDto
            {
                PassportNumber = user.Passport.PassportNumber,
                PassportName = user.Passport.PassportName,
                ExpiryDate = user.Passport.ExpiryDate,
                CountryOfProduction = user.Passport.CountryOfProduction
            },
           
            Address = new AddAddressDto
            {
                Street = user.Address.Street,
                City = user.Address.City,
                Country = user.Address.Country
            }
        };

        return new GeneralResult<ReadUserProfileDto>
        {
            Success = true,
            Message = "User profile retrieved successfully",
            Data = profileDto
        };

    }
    public async Task<GeneralResult> UpdateUserProfileAsync(Guid userId, UpdateUserProfileDto dto)
    {
        var user = await _unitOfWork.UserRepository.GetUserWithDetailsAsync(userId);

        if (user == null)
        {
            return new GeneralResult
            {
                Success = false,
                Message = "User profile not found"
            };
        }

        user.FirstName = dto.FirstName;
        user.LastName = dto.LastName;
        user.Gender = dto.Gender;
        user.DateOfBirth = dto.DateOfBirth;
        user.Nationality = dto.Nationality;
        user.Email = dto.Email;
        user.Level.Name = dto.Level.Name;
        user.Level.Description = dto.Level.Description;
        user.Level.DiscountPercentage = dto.Level.DiscountPercentage;
        user.Level.IsFreeTransportation = dto.Level.IsFreeTransportation;
        if (user.ProfileImage != null)
        {
            user.ProfileImage.ImageURL = dto.ImageURL;
        }
        
        user.Address.Street = dto.Address.Street;
        user.Address.City = dto.Address.City;
        user.Address.Country = dto.Address.Country;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new GeneralResult
        {
            Success = true,
            Message = "User profile updated successfully"
        };
    }



    public async Task<GeneralResult> UpdatePassportAsync(Guid userId, UpdatePassportDto dto)
    {
        var user = await _unitOfWork.UserRepository.GetUserWithDetailsAsync(userId);

        if (user == null || user.Passport == null)
        {
            return new GeneralResult
            {
                Success = false,
                Message = "Passport not found"
            };
        }

        user.Passport.PassportNumber = dto.PassportNumber;
        user.Passport.PassportName = dto.PassportName;
        user.Passport.ExpiryDate = dto.ExpiryDate;
        user.Passport.CountryOfProduction = dto.CountryOfProduction;

        await _unitOfWork.UserRepository.UpdateAsync(user);
        await _unitOfWork.SaveChangesAsync();

        return new GeneralResult
        {
            Success = true,
            Message = "Passport updated successfully"
        };
    }



    public Task<GeneralResult<string>> UpdateProfileImageAsync(Guid userId, IFormFile file)
    {
        throw new NotImplementedException();
    }

    
}
}

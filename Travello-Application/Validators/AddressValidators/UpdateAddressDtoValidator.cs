using FluentValidation;
using Travello_Application.Dtos;

namespace Travello_Application.Validators;

public class UpdateAddressDtoValidator : AbstractValidator<UpdateAddressDto>
{
    public UpdateAddressDtoValidator()
    {
        RuleFor(x => x.Street)
            .NotEmpty().WithMessage("Street is required.")
            .MaximumLength(100).WithMessage("Street cannot exceed 100 characters.");
        RuleFor(x => x.City)
            .NotEmpty().WithMessage("City is required.")
            .MaximumLength(50).WithMessage("City cannot exceed 50 characters.");
        RuleFor(x => x.Country)
            .NotEmpty().WithMessage("Country is required.")
            .MaximumLength(50).WithMessage("Country cannot exceed 50 characters.");
        RuleFor(x => x.Governorate)
            .NotEmpty().WithMessage("Government is required.")
            .MaximumLength(50).WithMessage("Government cannot exceed 50 characters.");
        RuleFor(x => x.ZipCode)
            .NotEmpty().WithMessage("ZipCode is required.")
            .Matches(@"^\d{5}(-\d{4})?$").WithMessage("ZipCode must be a valid format.");
    }
}


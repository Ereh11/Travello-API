using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Dtos.Hotel;

namespace Travello_Application.Validators;

public class AddHotelDtoValidator : AbstractValidator<AddHotelDto>
{
    public AddHotelDtoValidator()
    {
        RuleFor(h => h.Name)
            .NotEmpty().WithMessage("Hotel name is required.")
            .MaximumLength(100).WithMessage("Hotel name must not exceed 100 characters.");
        RuleFor(h => h.Description)
            .NotEmpty().WithMessage("Hotel description is required.")
            .MaximumLength(3000).WithMessage("Hotel description must not exceed 3000 characters.");
        RuleFor(h => h.Stars)
            .InclusiveBetween(1, 5).WithMessage("Stars must be between 1 and 5.");
        RuleFor(h => h.AddressId)
            .NotEmpty().WithMessage("Address ID is required.");
    }
}

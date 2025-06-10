using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Travello_Application.Dtos;

namespace Travello_Application.Validators;

public class UploadHotelImageDtoValidator : AbstractValidator<UploadHotelImageDto>
{
    public UploadHotelImageDtoValidator()
    {
        RuleFor(x => x.File)
            .NotNull()
            .WithMessage("File is required.")
            .Must(file => file.Length > 0)
            .WithMessage("File cannot be empty.")
            .Must(file => file.Length <= 10 * 1024 * 1024)
            .WithMessage("File size must not exceed 10 MB.")
            .Must(file => file.ContentType.StartsWith("image/"))
            .WithMessage("File must be an image.");
    }
}

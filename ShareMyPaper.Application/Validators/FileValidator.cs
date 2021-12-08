using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace ShareMyPaper.Application.Validators;
public class FileValidator : AbstractValidator<IFormFile>
{
    public FileValidator()
    {
        RuleFor(x => x.Length).NotNull().LessThanOrEqualTo(5000000)
            .WithMessage("File size can't be greater than 5MB");
        RuleFor(x => x.ContentType).NotNull().Must(x => x.Equals("image/jpeg") || x.Equals("image/jpg") || x.Equals("image/png") || x.Equals("application/pdf"))
            .WithMessage("File type is not allowed, use .jpg, .jpeg or .pdf instead");

    }
}

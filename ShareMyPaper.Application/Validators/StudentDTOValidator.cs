using FluentValidation;
using ShareMyPaper.Application.Input.Dtos;

namespace ShareMyPaper.Application.Validators;
public class StudentDTOValidator : AbstractValidator<StudentInputDTO>
{
    public StudentDTOValidator()
    {
        RuleFor(x => x.UploadedFile).NotEmpty();
        RuleFor(x => x.UploadedFile).SetValidator(new FileValidator()).When(x => x.UploadedFile is not null);
    }
}

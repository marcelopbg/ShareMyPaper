using FluentValidation;
using ShareMyPaper.Application.Dtos.Input;

namespace ShareMyPaper.Application.Validators;
public class InstitutionDTOValidator: AbstractValidator<InstitutionInputDTO>
{
    public InstitutionDTOValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.State).NotEmpty();
        RuleFor(x => x.Country).NotEmpty();
        RuleFor(x => x.City).NotEmpty();
    }
}

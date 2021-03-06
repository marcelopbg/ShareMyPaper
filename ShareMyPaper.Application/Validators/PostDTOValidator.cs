using FluentValidation;
using ShareMyPaper.Application.Dtos.Input;

namespace ShareMyPaper.Application.Validators;
public class PostDTOValidator : AbstractValidator<PostInputDTO>
{
    public PostDTOValidator()
    {
        RuleFor(x => x.UploadedFile).NotEmpty();
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.KnowledgeAreaId).Must(knowledgeArea => knowledgeArea > 0).WithMessage("'KnwoledgeArea' field must be specified");
        RuleFor(x => x.UploadedFile).SetValidator(new FileValidator()).When(x => x.UploadedFile is not null);
    }
}
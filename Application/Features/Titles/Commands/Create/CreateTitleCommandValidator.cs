using FluentValidation;

namespace Application.Features.Titles.Commands.Create
{
    public class CreateTitleCommandValidator : AbstractValidator<CreateTitleCommand>
    {

        public CreateTitleCommandValidator() 
        {
            RuleFor(i => i.TitleName).NotEmpty().WithMessage("Title alanı boş bırakılamaz.");
        }
    }
}

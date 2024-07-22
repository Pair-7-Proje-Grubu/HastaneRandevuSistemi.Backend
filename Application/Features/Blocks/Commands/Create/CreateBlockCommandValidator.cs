using FluentValidation;

namespace Application.Features.Blocks.Commands.Create
{
    public class CreateBlockCommandValidator : AbstractValidator<CreateBlockCommand>
    {
        public CreateBlockCommandValidator()
        {
            RuleFor(x => x.No).NotEmpty().WithMessage("No alanı boş olamaz.");
        }
    }
}

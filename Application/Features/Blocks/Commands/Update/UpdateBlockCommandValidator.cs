using FluentValidation;

namespace Application.Features.Blocks.Commands.Update
{
    public class UpdateBlockCommandValidator : AbstractValidator<UpdateBlockCommand>
    {
        public UpdateBlockCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz.");

            RuleFor(x => x.No).NotEmpty().WithMessage("No alanı boş olamaz.");
        }
    }
}

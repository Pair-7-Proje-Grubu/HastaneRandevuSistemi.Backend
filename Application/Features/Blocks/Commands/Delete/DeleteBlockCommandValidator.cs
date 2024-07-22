using FluentValidation;

namespace Application.Features.Blocks.Commands.Delete
{
    public class DeleteBlockCommandValidator : AbstractValidator<DeleteBlockCommand>
    {
        public DeleteBlockCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}

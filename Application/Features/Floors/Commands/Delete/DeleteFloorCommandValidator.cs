using FluentValidation;

namespace Application.Features.Floors.Commands.Delete
{
    public class DeleteFloorCommandValidator : AbstractValidator<DeleteFloorCommand>
    {
        public DeleteFloorCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

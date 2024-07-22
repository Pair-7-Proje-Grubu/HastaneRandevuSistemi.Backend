using FluentValidation;

namespace Application.Features.OfficeLocations.Commands.Delete
{
    public class DeleteOfficeLocationCommandValidator : AbstractValidator<DeleteOfficeLocationCommand>
    {
        public DeleteOfficeLocationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

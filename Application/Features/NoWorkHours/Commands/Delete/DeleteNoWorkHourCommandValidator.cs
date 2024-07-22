using FluentValidation;

namespace Application.Features.NoWorkHours.Commands.Delete
{
    public class DeleteNoWorkHourCommandValidator : AbstractValidator<DeleteNoWorkHourCommand>
    {
        public DeleteNoWorkHourCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

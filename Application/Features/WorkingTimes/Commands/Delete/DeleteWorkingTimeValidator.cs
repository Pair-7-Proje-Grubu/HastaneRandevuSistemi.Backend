using FluentValidation;

namespace Application.Features.WorkingTimes.Commands.Delete
{
    public class DeleteWorkingTimeValidator : AbstractValidator<DeleteWorkingTimeCommand>
    {
        public DeleteWorkingTimeValidator()
        {
            RuleFor(w => w.Id).NotEmpty();  
        }
    }
}

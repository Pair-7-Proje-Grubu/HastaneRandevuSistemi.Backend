using FluentValidation;

namespace Application.Features.WorkingTimes.Commands.Create
{
    public class CreateWorkingTimeValidator : AbstractValidator<CreateWorkingTimeCommand>
    {
        public CreateWorkingTimeValidator()
        {
            RuleFor(w => w.StartTime).NotEmpty();
            RuleFor(w => w.EndTime).NotEmpty();
            RuleFor(w => w.StartBreakTime).NotEmpty();
            RuleFor(w => w.EndBreakTime).NotEmpty();
        }
    }
}

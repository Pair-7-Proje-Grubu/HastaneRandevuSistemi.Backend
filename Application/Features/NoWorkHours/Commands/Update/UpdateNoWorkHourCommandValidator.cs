using FluentValidation;

namespace Application.Features.NoWorkHours.Commands.Update
{
    public class UpdateNoWorkHourCommandValidator : AbstractValidator<UpdateNoWorkHourCommand>
    {
        public UpdateNoWorkHourCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();


            RuleFor(x => x.Id).GreaterThan(0);

        }
    }
}

using FluentValidation;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourCommandValidator : AbstractValidator<CreateNoWorkHourCommand>
    {
        public CreateNoWorkHourCommandValidator()
        {
        }
    }
}

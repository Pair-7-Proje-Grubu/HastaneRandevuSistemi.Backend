using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.NoWorkHours.Commands.Create
{
    public class CreateNoWorkHourCommandValidator : AbstractValidator<CreateNoWorkHourCommand>
    {
        public CreateNoWorkHourCommandValidator()
        {
            RuleFor(p => p.DateTime)
                .NotEmpty().WithMessage("DateTime is required.")
                .NotNull()
                .LessThan(DateTime.Now).WithMessage("{PropertyName} should be less than today.");
        }
    }
}

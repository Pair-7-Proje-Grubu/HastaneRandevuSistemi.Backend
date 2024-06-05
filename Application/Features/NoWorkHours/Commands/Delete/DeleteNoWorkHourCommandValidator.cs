using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

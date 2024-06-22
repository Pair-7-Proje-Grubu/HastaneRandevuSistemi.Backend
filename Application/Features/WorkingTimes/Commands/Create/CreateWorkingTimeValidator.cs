using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

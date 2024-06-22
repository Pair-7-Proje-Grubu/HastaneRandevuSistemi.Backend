using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

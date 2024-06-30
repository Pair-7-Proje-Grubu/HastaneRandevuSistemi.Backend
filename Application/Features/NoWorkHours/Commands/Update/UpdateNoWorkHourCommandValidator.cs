using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

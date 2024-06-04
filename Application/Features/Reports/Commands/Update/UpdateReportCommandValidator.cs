using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Commands.Update
{
    public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
    {
        public UpdateReportCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();

            RuleFor(x => x.AppointmentId).NotEmpty();

            RuleFor(x => x.Description).NotEmpty();

            RuleFor(x => x.Id).GreaterThan(0);

            RuleFor(x => x.AppointmentId).GreaterThan(0);

            RuleFor(x => x.Description).MaximumLength(500);
        }
    }
}

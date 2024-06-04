using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Commands.Create
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator()
        {
            RuleFor(x => x.AppointmentId).NotEmpty().WithMessage("AppointmentId boş olamaz.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Description boş olamaz.");

            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description 500 karakterden fazla olamaz.");

            RuleFor(x => x.AppointmentId).GreaterThan(0).WithMessage("AppointmentId 0'dan büyük olmalıdır.");
        }
    }
}

using Application.Features.Appointments.Commands.Book;
using Application.Features.Appointments.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.ByPatient
{
    public class CancelAppointmentByPatientCommandValidator : AbstractValidator<CancelAppointmentByPatientCommand>
    {
        public CancelAppointmentByPatientCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}

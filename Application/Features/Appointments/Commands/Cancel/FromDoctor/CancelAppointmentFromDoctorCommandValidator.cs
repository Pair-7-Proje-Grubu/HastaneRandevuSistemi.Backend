using Application.Features.Appointments.Commands.Cancel;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.FromDoctor
{
    public class CancelAppointmentFromDoctorCommandValidator : AbstractValidator<CancelAppointmentFromDoctorCommand>
    {
        public CancelAppointmentFromDoctorCommandValidator() { }
    }
}

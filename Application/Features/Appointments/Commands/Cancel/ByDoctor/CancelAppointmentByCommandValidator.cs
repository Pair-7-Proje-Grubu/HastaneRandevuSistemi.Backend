using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Cancel.ByDoctor
{
    public class CancelAppointmentByDoctorCommandValidator : AbstractValidator<CancelAppointmentByDoctorCommand>
    {
        public CancelAppointmentByDoctorCommandValidator() { }
    }
}

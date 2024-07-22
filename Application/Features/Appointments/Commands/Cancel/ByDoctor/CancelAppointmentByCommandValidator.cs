using FluentValidation;

namespace Application.Features.Appointments.Commands.Cancel.ByDoctor
{
    public class CancelAppointmentByDoctorCommandValidator : AbstractValidator<CancelAppointmentByDoctorCommand>
    {
        public CancelAppointmentByDoctorCommandValidator()
        {
            RuleFor(a => a.Id).NotEmpty();
        }
    }
}

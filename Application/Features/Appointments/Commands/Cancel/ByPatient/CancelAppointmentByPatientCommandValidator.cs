using FluentValidation;

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

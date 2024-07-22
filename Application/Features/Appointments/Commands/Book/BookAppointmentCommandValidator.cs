using Application.Features.Appointments.Constants;
using FluentValidation;

namespace Application.Features.Appointments.Commands.Book
{
    public class BookAppointmentCommandValidator : AbstractValidator<BookAppointmentCommand>
    {
        public BookAppointmentCommandValidator()
        {
            RuleFor(a => a.DoctorId).NotEmpty();
            RuleFor(a => a.DateTime).NotEmpty().GreaterThan(DateTime.Now).LessThan(DateTime.Now.AddDays(AppointmentsValues.availableAppointmentsDayLimit));
        }
    }
}

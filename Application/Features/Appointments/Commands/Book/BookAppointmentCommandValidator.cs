using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commands.Book
{
    public class BookAppointmentCommandValidator : AbstractValidator<BookAppointmentCommand>
    {
        public BookAppointmentCommandValidator()
        {
            RuleFor(a => a.DoctorId).NotEmpty();
            RuleFor(a => a.DateTime).NotEmpty().GreaterThan(DateTime.Now).LessThan(DateTime.Now.AddDays(15));
        }
    }
}

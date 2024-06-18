using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Create
{
    public class CreateClinicCommandValidator : AbstractValidator<CreateClinicCommand>
    {

        public CreateClinicCommandValidator() 
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Klinik alanı boş bırakılamaz.");
            RuleFor(i => i.PhoneNumber).NotEmpty().WithMessage("Telefon alanı boş bırakılamaz.");
            RuleFor(i => i.AppointmentDuration).NotEmpty().WithMessage("Randevu süresi alanı boş bırakılamaz.");
        }
    }
}

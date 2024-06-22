using Application.Services.ValidatorService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auth.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(r => r.FirstName).NotEmpty().Length(2, 50).Matches(@"^[\p{L}\p{M}]+$");
            RuleFor(r => r.LastName).NotEmpty().Length(2, 50).Matches(@"^[\p{L}\p{M}]+$");

            RuleFor(r => r.BirthDate)
            .NotEmpty()
            .Must(BeAValidDate).WithMessage("Please enter a valid date.")
            .Must(BeAReasonableAge).WithMessage("Please enter a reasonable birthdate.");

            RuleFor(r => r.Gender).NotEmpty().Must(BeValidGender).WithMessage("Gender can only be 'M', 'F' or 'U'.");
            RuleFor(r => r.Email).NotEmpty().Length(10, 50).EmailAddress();
            RuleFor(r => r.Phone).NotEmpty().Matches(@"^\+?\d{10,15}$");
            RuleFor(r => r.Password).NotEmpty().Length(6, 30);
        }

        private bool BeValidGender(char gender)
        {
            return gender == 'M' || gender == 'F' || gender == 'U';
        }

        private bool BeAValidDate(DateTime date)
        {
            return !date.Equals(default(DateTime));
        }

        private bool BeAReasonableAge(DateTime date)
        {
            var minDate = DateTime.Now.AddYears(-140); // 140 yaşından büyük olmamalı
            var maxDate = DateTime.Now.AddDays(1); // Gelecekte olmamalı (1 günlük tolerans)

            return date > minDate && date < maxDate;
        }
    }
}

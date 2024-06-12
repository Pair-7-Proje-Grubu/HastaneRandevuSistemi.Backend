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
            RuleFor(r => r.FirstName).NotEmpty().WithMessage(ValidationMessages.Required)
                .DependentRules(() =>
                {
                    RuleFor(r => r.FirstName)
                    .Length(2, 50).WithMessage(ValidationMessages.Length)
                    .Matches("^[a-zA-Z]+$").WithMessage(ValidationMessages.OnlyLetters).WithName("Ad");
                }).WithName("Ad");

            RuleFor(r => r.LastName).NotEmpty().WithMessage(ValidationMessages.Required).WithName("Soyad")
                .Length(2, 50).WithMessage(ValidationMessages.Length).WithName("Soyad")
                .Matches("^[a-zA-Z]+$").WithMessage(ValidationMessages.OnlyLetters).WithName("Soyad");

            RuleFor(r => r.Email).NotEmpty().WithMessage(ValidationMessages.Required)
                .EmailAddress().WithMessage(ValidationMessages.InvalidFormat);

            RuleFor(r => r.Phone).NotEmpty().WithMessage(ValidationMessages.Required).WithName("Telefon numarası")
                .Matches(@"^\+?\d{10,15}$").WithMessage(ValidationMessages.InvalidFormat).WithName("Telefon numarası");

            RuleFor(r => r.Password).NotEmpty().WithMessage(ValidationMessages.Required).WithName("Şifre")
                .MinimumLength(6).WithMessage(ValidationMessages.Length).WithName("Şifre");
        }
    }
}

using FluentValidation;

namespace Application.Features.Users.Commands.Update.ChangePhoneNumber
{
    public class ChangePhoneNumberCommandValidator : AbstractValidator<ChangePhoneNumberCommand>
    {
        public ChangePhoneNumberCommandValidator()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.NewPhone).NotEmpty().Matches(@"^[0-9]{10}$").WithMessage("Telefon numarası 10 haneli olmalı ve sadece rakamlardan oluşmalıdır.");
        }
    }
}
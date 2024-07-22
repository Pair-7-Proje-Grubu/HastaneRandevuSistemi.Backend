using FluentValidation;

namespace Application.Features.Users.Commands.Update.ChangePassword
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator()
        {
            RuleFor(r => r.NewPassword).NotEmpty().Length(6, 30);
        }
    }
}

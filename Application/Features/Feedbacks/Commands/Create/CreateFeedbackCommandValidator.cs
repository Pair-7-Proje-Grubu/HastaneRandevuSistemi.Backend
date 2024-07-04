using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Feedbacks.Commands.Create
{
    public class CreateFeedbackCommandValidator : AbstractValidator<CreateFeedbackCommand>
    {
        public CreateFeedbackCommandValidator()
        {
            RuleFor(i => i.UserMail).NotEmpty().WithMessage("Kullanıcı mail alanı boş bırakılamaz.");
            RuleFor(i => i.UserMail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz.");
            RuleFor(i => i.UserMail).MinimumLength(10).WithMessage("Kullanıcı mail alanı en az 10 karakter olabilir.");
            RuleFor(i => i.UserMail).MaximumLength(50).WithMessage("Kullanıcı mail alanı en fazla 50 karakter olabilir.");

            RuleFor(i => i.UserFeedback).NotEmpty().WithMessage("Kullanıcı geri bildirimi alanı boş bırakılamaz.");
            RuleFor(i => i.UserFeedback).MinimumLength(10).WithMessage("Kullanıcı geri bildirimi alanı en az 10 karakter olabilir.");
            RuleFor(i => i.UserFeedback).MaximumLength(500).WithMessage("Kullanıcı geri bildirimi alanı en fazla 500 karakter olabilir.");
        }
    }
}
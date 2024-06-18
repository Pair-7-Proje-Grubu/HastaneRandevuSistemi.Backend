using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Create
{
    public class CreateTitleCommandValidator : AbstractValidator<CreateTitleCommand>
    {

        public CreateTitleCommandValidator() 
        {
            RuleFor(i => i.TitleName).NotEmpty().WithMessage("Title alanı boş bırakılamaz.");
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Commands.Create
{
    public class CreateAllergyCommandValidator : AbstractValidator<CreateAllergyCommand>
    {

        public CreateAllergyCommandValidator() 
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Alerji alanı boş bırakılamaz.");
        }
    }
}

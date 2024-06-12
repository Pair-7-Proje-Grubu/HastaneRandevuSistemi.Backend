using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Commands.Update
{
    public class UpdateAllergyCommandValidator : AbstractValidator<UpdateAllergyCommand>
    {
        public UpdateAllergyCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }

    }
}

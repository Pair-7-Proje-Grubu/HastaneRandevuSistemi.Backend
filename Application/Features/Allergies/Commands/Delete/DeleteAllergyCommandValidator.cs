using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Allergies.Commands.Delete
{
    public class DeleteAllergyCommandValidator : AbstractValidator<DeleteAllergyCommand>
    {
        public DeleteAllergyCommandValidator() 
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}

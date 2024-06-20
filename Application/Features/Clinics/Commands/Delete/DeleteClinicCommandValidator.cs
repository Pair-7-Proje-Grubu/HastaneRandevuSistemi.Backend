using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Clinics.Commands.Delete
{
    public class DeleteClinicCommandValidator : AbstractValidator<DeleteClinicCommand>
    {
        public DeleteClinicCommandValidator() 
        {
            RuleFor(i => i.Id).NotEmpty();
        }

    }
}

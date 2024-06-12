using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Commands.Delete
{
    public class DeleteOfficeLocationCommandValidator : AbstractValidator<DeleteOfficeLocationCommand>
    {
        public DeleteOfficeLocationCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

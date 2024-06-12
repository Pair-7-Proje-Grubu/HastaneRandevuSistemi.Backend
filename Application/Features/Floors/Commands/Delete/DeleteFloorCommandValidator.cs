using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Commands.Delete
{
    public class DeleteFloorCommandValidator : AbstractValidator<DeleteFloorCommand>
    {
        public DeleteFloorCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

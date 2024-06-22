using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Commands.Delete
{
    public class DeleteBlockCommandValidator : AbstractValidator<DeleteBlockCommand>
    {
        public DeleteBlockCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.");
        }
    }
}

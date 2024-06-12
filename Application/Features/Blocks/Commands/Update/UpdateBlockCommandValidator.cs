using Application.Features.Reports.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Blocks.Commands.Update
{
    public class UpdateBlockCommandValidator : AbstractValidator<UpdateBlockCommand>
    {
        public UpdateBlockCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().NotNull().WithMessage("Id alanı boş olamaz.");

            RuleFor(x => x.No).NotEmpty().NotNull().NotNull().WithMessage("No alanı boş olamaz.");
        }
    }
}

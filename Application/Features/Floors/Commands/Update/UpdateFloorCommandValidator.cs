using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Commands.Update
{
    public class UpdateFloorCommandValidator : AbstractValidator<UpdateFloorCommand>
    {
        public UpdateFloorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı boş olamaz.");

            RuleFor(x => x.No).NotEmpty().NotNull().WithMessage("No alanı boş olamaz.");
        }
    }
}

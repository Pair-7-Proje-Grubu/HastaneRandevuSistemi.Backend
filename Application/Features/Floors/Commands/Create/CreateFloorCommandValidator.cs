using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Floors.Commands.Create
{
    public class CreateFloorCommandValidator : AbstractValidator<CreateFloorCommand>
    {
        public CreateFloorCommandValidator()
        {
            RuleFor(x => x.No).NotEmpty().NotNull().WithMessage("No alanı boş olamaz.");
        }
    }
}

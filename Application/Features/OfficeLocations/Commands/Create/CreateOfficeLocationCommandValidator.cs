using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Commands.Create
{
    public class CreateOfficeLocationCommandValidator : AbstractValidator<CreateOfficeLocationCommand>
    {
        public CreateOfficeLocationCommandValidator()
        {
            RuleFor(x => x.BlockId).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.FloorId).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.RoomId).NotEmpty().WithMessage("Id alanı boş olamaz.");
        }
    }
}

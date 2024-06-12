using Application.Features.Reports.Commands.Update;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OfficeLocations.Commands.Update
{
    public class UpdateOfficeLocationCommandValidator : AbstractValidator<UpdateOfficeLocationCommand>
    {
        public UpdateOfficeLocationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotNull().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.BlockId).NotEmpty().NotNull().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.FloorId).NotEmpty().NotNull().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.RoomId).NotEmpty().NotNull().WithMessage("Id alanı boş olamaz.");
        }
    }
}

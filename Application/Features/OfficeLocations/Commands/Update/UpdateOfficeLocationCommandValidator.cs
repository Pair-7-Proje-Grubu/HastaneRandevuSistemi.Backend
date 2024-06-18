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
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.BlockId).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.FloorId).NotEmpty().WithMessage("Id alanı boş olamaz.");
            RuleFor(x => x.RoomId).NotEmpty().WithMessage("Id alanı boş olamaz.");
        }
    }
}

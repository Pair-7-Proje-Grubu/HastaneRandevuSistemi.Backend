using FluentValidation;

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

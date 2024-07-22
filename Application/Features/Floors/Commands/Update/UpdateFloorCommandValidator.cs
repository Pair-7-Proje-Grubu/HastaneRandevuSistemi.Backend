using FluentValidation;

namespace Application.Features.Floors.Commands.Update
{
    public class UpdateFloorCommandValidator : AbstractValidator<UpdateFloorCommand>
    {
        public UpdateFloorCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Id alanı boş olamaz.");

            RuleFor(x => x.No).NotEmpty().WithMessage("No alanı boş olamaz.");
        }
    }
}

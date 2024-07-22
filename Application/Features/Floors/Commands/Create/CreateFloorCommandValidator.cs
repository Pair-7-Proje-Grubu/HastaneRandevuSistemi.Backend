using FluentValidation;

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

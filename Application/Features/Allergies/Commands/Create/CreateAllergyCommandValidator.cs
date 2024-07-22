using FluentValidation;

namespace Application.Features.Allergies.Commands.Create
{
    public class CreateAllergyCommandValidator : AbstractValidator<CreateAllergyCommand>
    {

        public CreateAllergyCommandValidator() 
        {
            RuleFor(i => i.Name).NotEmpty().WithMessage("Alerji alanı boş bırakılamaz.");
        }
    }
}

using FluentValidation;

namespace Application.Features.Allergies.Commands.Delete
{
    public class DeleteAllergyCommandValidator : AbstractValidator<DeleteAllergyCommand>
    {
        public DeleteAllergyCommandValidator() 
        {
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}

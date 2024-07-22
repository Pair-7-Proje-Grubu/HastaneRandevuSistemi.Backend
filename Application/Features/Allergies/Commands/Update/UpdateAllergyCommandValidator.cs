using FluentValidation;

namespace Application.Features.Allergies.Commands.Update
{
    public class UpdateAllergyCommandValidator : AbstractValidator<UpdateAllergyCommand>
    {
        public UpdateAllergyCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }

    }
}

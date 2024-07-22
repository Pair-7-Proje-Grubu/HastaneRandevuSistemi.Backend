using FluentValidation;

namespace Application.Features.Clinics.Commands.Update
{
    public class UpdateClinicCommandValidator : AbstractValidator<UpdateClinicCommand>
    {
        public UpdateClinicCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PhoneNumber).NotEmpty();

        }
    }
}

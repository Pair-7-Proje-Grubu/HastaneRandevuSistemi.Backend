using FluentValidation;

namespace Application.Features.Clinics.Commands.Delete
{
    public class DeleteClinicCommandValidator : AbstractValidator<DeleteClinicCommand>
    {
        public DeleteClinicCommandValidator() 
        {
            RuleFor(i => i.Id).NotEmpty();
        }

    }
}

using FluentValidation;

namespace Application.Features.Doctors.Commands.DeleteDoctor
{
    public class DeleteDoctorCommandValidator : AbstractValidator<DeleteDoctorCommand>
    {
        public DeleteDoctorCommandValidator()
        { 
            RuleFor(i=>i.Id).NotEmpty();
        }
    }
}

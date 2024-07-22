using FluentValidation;

namespace Application.Features.Doctors.Commands.UpdateDoctor
{
    public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
    {
        public UpdateDoctorCommandValidator()
        {
            RuleFor(d => d.Id).NotEmpty();
            RuleFor(d => d.ClinicId).NotEmpty();
            RuleFor(d => d.TitleId).NotEmpty();
        }
    }
}

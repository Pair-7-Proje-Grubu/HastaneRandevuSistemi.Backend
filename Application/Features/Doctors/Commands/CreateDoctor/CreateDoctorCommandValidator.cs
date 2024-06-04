using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Doctors.Commands.CreateDoctor
{
    public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
    {
        public CreateDoctorCommandValidator()
        { 
            RuleFor(i=>i.FirstName).NotEmpty();
            RuleFor(i => i.LastName).NotEmpty();
            RuleFor(i => i.Phone).NotEmpty();
            RuleFor(i => i.Email).NotEmpty();

            RuleFor(i => i.FirstName).MaximumLength(30);
            RuleFor(i => i.LastName).MaximumLength(30);
            //RuleFor(i => i.Phone).Length(11);
            //RuleFor(i => i.Email).Must(x=> x.Contains("@"));


        }
    }
}

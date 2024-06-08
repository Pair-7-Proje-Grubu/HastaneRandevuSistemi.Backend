﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

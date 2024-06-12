using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Update
{
    public class UpdateTitleCommandValidator : AbstractValidator<UpdateTitleCommand>
    {

        public UpdateTitleCommandValidator() 
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.TitleName).NotEmpty();
        }
    }
}

using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Titles.Commands.Delete
{
    public class DeleteTitleCommandValidator : AbstractValidator<DeleteTitleCommand>
    {

        public DeleteTitleCommandValidator() 
        {
            RuleFor(i => i.Id).NotEmpty();
        }    

    }
}

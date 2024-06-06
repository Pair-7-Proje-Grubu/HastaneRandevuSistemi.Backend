using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Reports.Commands.Delete
{
    public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
    {
        public DeleteReportCommandValidator()
        {
            RuleFor(p => p.Id)
                .NotEmpty().WithMessage("Id is required.")
                .NotNull();
        }
    }
}

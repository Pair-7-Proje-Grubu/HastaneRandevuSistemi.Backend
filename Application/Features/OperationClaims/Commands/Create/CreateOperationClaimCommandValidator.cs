using FluentValidation;

namespace Application.Features.OperationClaims.Commands.Create
{
    public class CreateOperationClaimCommandValidator : AbstractValidator<CreateOperationClaimCommand>
    {
        public CreateOperationClaimCommandValidator()
        {
            RuleFor(o => o.Name).NotEmpty();
        }
    }
}

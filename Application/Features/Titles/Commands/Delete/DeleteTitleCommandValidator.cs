using FluentValidation;

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

using FluentValidation;

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

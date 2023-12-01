using FluentValidation;

namespace Web.Buisness.Features.UiPageType.Commands
{

    public class UiPageTypeCreateCommandValidator : AbstractValidator<UiPageTypeCreateCommand>
    {
        public UiPageTypeCreateCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).WithMessage("Name Cannot be Null");
        }
    }
}

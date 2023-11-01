using FluentValidation;
using WebBuisness.Commands;
using WebBuisness.Models;

namespace Web.Buisness.Validations
{

    public class UiPageTypeCreateCommandValidator : AbstractValidator<UiPageTypeCreateCommand>
    {
        public UiPageTypeCreateCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).WithMessage("Name Cannot be Null");
        }
    }
}

using FluentValidation;

namespace WebBuisness.Models
{
    public class UiPageType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class UiPageTypeValidator : AbstractValidator<UiPageType>
    {
        public UiPageTypeValidator() 
        {
            RuleFor(x => x.Name).NotNull().MinimumLength(3).WithMessage("Name Cannot be Null");
        }
    }
}

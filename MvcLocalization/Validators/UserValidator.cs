using FluentValidation;
using Microsoft.Extensions.Localization;
using MvcLocalization.Models;

namespace MvcLocalization.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator(IStringLocalizer localizer)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizer["Toto pole je povinné. Vyplňte jej prosím."]);
            RuleFor(x => x.Name).CustomPropertyValidator().WithMessage(localizer["Hodnota je špatně. Správná hodnota je: {CorrectValue}"]);
            RuleFor(x => x.ChildrenCount).InclusiveBetween(0, 10).WithMessage(localizer["Hodnota není v povoleném rozsahu. Zadejte prosím celé číslo od {From} do {To}"]);
        }
    }
}

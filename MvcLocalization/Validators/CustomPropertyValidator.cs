using FluentValidation;
using FluentValidation.Resources;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLocalization.Validators
{
    public class CustomPropertyValidator : PropertyValidator
    {
        public CustomPropertyValidator() : base(new LanguageStringSource(nameof(CustomPropertyValidator)))
        {
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (context.PropertyValue is string s && s == "VALID")
                return true;

            context.MessageFormatter.AppendArgument("CorrectValue", "VALID");
            return false;
        }
    }

    public static class CustomValidatorExtensions{
        public static IRuleBuilderOptions<T, TProperty> CustomPropertyValidator<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new CustomPropertyValidator());
        }
    }
}

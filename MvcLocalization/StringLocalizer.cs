using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MvcLocalization
{
    public class StringLocalizer : IStringLocalizer
    {
        private readonly ILanguage _lang;

        public StringLocalizer(ILanguage lang)
        {
            _lang = lang;
        }

        public LocalizedString this[string name] => new LocalizedString(name, $"{name} [{_lang.Code}]");

        public LocalizedString this[string name, params object[] arguments] => throw new NotImplementedException();

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return new LocalizedString[0];
        }

        public IStringLocalizer WithCulture(CultureInfo culture)
        {
            return this;
        }
    }
}

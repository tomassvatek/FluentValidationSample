namespace MvcLocalization
{
    public class Language : ILanguage
    {
        public string Code { get; set; }
    }

    public interface ILanguage
    {
        public string Code { get; set; }
    }
}

namespace MvcLocalization
{
    public class Language : ILanguage
    {
        public string Code { get; set; }
    }

    public interface ILanguage
    {
        string Code { get; set; }
    }
}

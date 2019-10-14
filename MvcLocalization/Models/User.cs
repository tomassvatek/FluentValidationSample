using System.ComponentModel.DataAnnotations;

namespace MvcLocalization.Models
{
    public class User
    {
        public long Id { get; set; }

        //[Required(ErrorMessage = "Jméno je povinné")]
        public string Name { get; set; }
        //[Range(0, 10, ErrorMessage = "Mimo rozsah")]
        public int ChildrenCount { get; set; }
    }
}

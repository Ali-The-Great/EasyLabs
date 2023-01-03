using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EasyLabs.Models
{
    public class LogInModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        public string mail { get; set; }
        //----------------------------------------------------------------|
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        public string password { get; set; }

        internal static DataLibrary.Models.LogInModel LITransform(LogInModel Lim)
        {
            DataLibrary.Models.LogInModel dim = new DataLibrary.Models.LogInModel(Lim.mail, "" , Lim.password);
            return dim;
        }
    }
}

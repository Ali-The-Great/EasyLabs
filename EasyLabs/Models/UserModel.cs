using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace EasyLabs.Models
{
    public class UserModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "This field is required")]
        public string name { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Phone Number")]
        public string phone_number { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        public string mail { get; set; }
        //----------------------------------------------------------------|
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        public string password { get; set; }
        //----------------------------------------------------------------|
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "This field is required")]
        [Compare("password", ErrorMessage ="Passwords do not match.")]
        public string confirmPassword { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "This field is required")]
        public string gender { get; set; }


        public static DataLibrary.Models.UserModel UTransform(UserModel um) 
        {
            DataLibrary.Models.UserModel dum = new DataLibrary.Models.UserModel(um.name, um.phone_number, um.mail, "", um.password, um.gender);
            return dum;
        }
    }
}

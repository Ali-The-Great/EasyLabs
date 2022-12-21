using System.ComponentModel.DataAnnotations;

namespace EasyLabs.Models
{
    public class UserModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Phone Number")]
        public string phone_number { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Email")]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "This field is required")]
        public string ConfirmPassword { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "This field is required")]
        public string Gender { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "This field is required")]
        public DateOnly birth_date { get; set; }
        //----------------------------------------------------------------|
        [Display(Name = "Are you an employee?")]
        public bool EmpOrNot { get; set; }
        //----------------------------------------------------------------|
        /*
        public static Datalibrary.Models.UserModel UModelTransform(UserModel um)
        {
            Datalibrary.Models.UserModel dum = new Datalibrary.Models.UserModel(um.Email, um.Password);
            return dum;
        }*/

    }
}

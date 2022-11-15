using System.ComponentModel.DataAnnotations;

namespace EasyLabs.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "This field is required")]
        public string Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "This field is required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "This field is required")]
        public string ConfirmPassword { get; set; }
       
    }
}

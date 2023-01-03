using System.ComponentModel.DataAnnotations;

namespace EasyLabs.Models
{
    public class AppointmentModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Appointment Date")]
        [Required(ErrorMessage = "This field is required")]
        public DateTime Date { get; set; }

        [Display(Name = "Test Type")]
        [Required(ErrorMessage = "This field is required")]
        public string Test_Type { get; set; }

    }
}

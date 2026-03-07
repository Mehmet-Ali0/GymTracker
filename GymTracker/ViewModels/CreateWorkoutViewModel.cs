using System.ComponentModel.DataAnnotations;

namespace GymTracker.ViewModels
{
    public class CreateWorkoutViewModel
    {

        [Required(ErrorMessage = "Name can not be empty")]
        [Display(Name = "Workout Name")]
        [StringLength(50, ErrorMessage = "Keep the name under 50 characters.")]
        public string Name { get; set; }


    }
}

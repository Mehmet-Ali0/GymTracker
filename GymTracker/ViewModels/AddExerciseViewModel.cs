using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GymTracker.ViewModels
{
    public class AddExerciseViewModel
    {
        
        public int WorkoutTemplateId { get; set; }

        
        [Required(ErrorMessage = "Please select an exercise.")]
        [Display(Name = "Exercise")]
        public int SelectedExerciseId { get; set; }

     
        public IEnumerable<SelectListItem> AvailableExercises { get; set; } = new List<SelectListItem>();

        
        [Required(ErrorMessage = "Please enter target sets.")]
        [Range(1, 20, ErrorMessage = "Sets must be between 1 and 20.")]
        [Display(Name = "Target Sets")]
        public int TargetSets { get; set; }
    }
}
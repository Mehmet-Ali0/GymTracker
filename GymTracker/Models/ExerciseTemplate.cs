using System.ComponentModel.DataAnnotations;

namespace GymTracker.Models
{
    public class ExerciseTemplate
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int TargetSets { get; set; }

        [Required]
        public int OrderSequence { get; set; }

        //Connections

        public int WorkoutTemplateID { get; set; }
        public WorkoutTemplate WorkoutTemplate { get; set; }
        
        public int ExerciseID { get; set; }
        public Exercise Exercise { get; set; }







    }
}

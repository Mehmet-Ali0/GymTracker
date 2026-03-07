using System.ComponentModel.DataAnnotations;

namespace GymTracker.Models
{
    public class SetRecord
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public int SetNumber { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int Reps { get; set; }

        //Connections

        public WorkoutSession WorkoutSession { get; set; }
        public int WorkoutSessionId { get; set; }

        public Exercise Exercise { get; set; }
        public int ExerciseId { get; set; }







    }
}

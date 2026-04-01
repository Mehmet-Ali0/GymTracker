using System.ComponentModel.DataAnnotations;
 

namespace GymTracker.Models
{
    public class WorkoutTemplate
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsArchived { get; set; } = false;

        //Connection
        [Required]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

   
        public ICollection<ExerciseTemplate> ExerciseTemplates { get; set; } = new List<ExerciseTemplate>();

        public ICollection<WorkoutSession> WorkoutSessions { get; set; } = new List<WorkoutSession>();










    }
}

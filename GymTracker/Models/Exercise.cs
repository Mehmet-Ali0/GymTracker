using System.ComponentModel.DataAnnotations;

namespace GymTracker.Models
{
    public class Exercise
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string TargetMuscle { get; set; }
    
        //Connections
        public ICollection<ExerciseTemplate> ExerciseTemplates { get; set; } = new List<ExerciseTemplate>();

        public ICollection<SetRecord> SetRecords { get; set; } = new List<SetRecord>();



    }
}

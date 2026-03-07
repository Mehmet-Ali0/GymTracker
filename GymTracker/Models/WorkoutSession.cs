using System.ComponentModel.DataAnnotations;

namespace GymTracker.Models
{
    public class WorkoutSession
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public DateOnly DatePerformed { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        //Connections

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    
        public WorkoutTemplate WorkoutTemplate { get; set; }
        public int WorkoutTemplateId { get; set; }  

        public ICollection<SetRecord> SetRecords { get; set; } = new List<SetRecord>();
    
    
    
    }
}

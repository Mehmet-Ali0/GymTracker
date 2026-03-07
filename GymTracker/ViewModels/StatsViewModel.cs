using System.Collections.Generic;

namespace GymTracker.ViewModels
{
    
    public class StatsViewModel
    {
        
        public List<MuscleVolumeItem> MuscleVolumeData { get; set; } = new List<MuscleVolumeItem>();

        
        public List<ExerciseDropdownItem> AvailableExercises { get; set; } = new List<ExerciseDropdownItem>();
    }

    
    public class MuscleVolumeItem
    {
        public string MuscleGroup { get; set; } 
        public int TotalSets { get; set; }      
    }

    
    public class ExerciseDropdownItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    
    public class ExerciseProgressItem
    {
        public string DateString { get; set; } 
        public double MaxWeight { get; set; }  
    }
}
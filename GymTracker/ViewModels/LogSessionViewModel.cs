namespace GymTracker.ViewModels
{
    public class LogSessionViewModel
    {
        public int SessionId { get; set; }
        public string WorkoutName { get; set; }
        public List<ExerciseLogViewModel> Exercises { get; set; } = new();
    }

    public class ExerciseLogViewModel
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }
        public int TargetSets { get; set; }
       
        public List<SetEntryViewModel> Sets { get; set; } = new();
    }

    public class SetEntryViewModel
    {
        public int? SetRecordId { get; set; }
        public double? Weight { get; set; }
        public int? Reps { get; set; }
    }
}
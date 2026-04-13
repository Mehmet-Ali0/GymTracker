using GymTracker.Models;

namespace GymTracker.ViewModels
{
    public class HistoryCalendarViewModel
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }

        public int DaysInMonth { get; set; }

        // Tells us if the 1st of the month is a Monday, Tuesday, etc. so we can draw empty calendar boxes
        public int StartDayOfWeek { get; set; }

        // A dictionary where the Key is the Day (1-31) and the Value is the list of workouts for that day
        public Dictionary<int, List<WorkoutSession>> WorkoutsByDay { get; set; } = new Dictionary<int, List<WorkoutSession>>();
    }
}
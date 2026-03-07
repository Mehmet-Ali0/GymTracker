using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using GymTracker.Models;
using Microsoft.Identity.Client;

namespace GymTracker.Data
{
    
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {        
        }

        public DbSet<Exercise> exercises { get; set; }
        public DbSet<WorkoutTemplate> WorkoutTemplates { get; set; }
        public DbSet<ExerciseTemplate> ExerciseTemplates { get; set; }
        public DbSet<WorkoutSession> WorkoutSessions { get; set; }
        public DbSet<SetRecord> SetRecords { get; set; }

        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           
            base.OnModelCreating(builder);

            
            builder.Entity<WorkoutSession>()
                .HasOne(ws => ws.WorkoutTemplate)
                .WithMany(wt => wt.WorkoutSessions)
                .HasForeignKey(ws => ws.WorkoutTemplateId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Exercise>().HasData(
            new Exercise { Id = 1, Name = "Barbell Bench Press", TargetMuscle = "Chest" },
             new Exercise { Id = 2, Name = "Incline Dumbbell Press", TargetMuscle = "Chest" },
             new Exercise { Id = 3, Name = "Chest Fly (Cable/Machine)", TargetMuscle = "Chest" },
             new Exercise { Id = 4, Name = "Overhead Press", TargetMuscle = "Shoulders" },
             new Exercise { Id = 5, Name = "Lateral Raise", TargetMuscle = "Shoulders" },
             new Exercise { Id = 6, Name = "Barbell Squat", TargetMuscle = "Legs" },
             new Exercise { Id = 7, Name = "Leg Press", TargetMuscle = "Legs" },
             new Exercise { Id = 8, Name = "Leg Extension", TargetMuscle = "Legs" },
             new Exercise { Id = 9, Name = "Leg Curl", TargetMuscle = "Legs" },
             new Exercise { Id = 10, Name = "Deadlift", TargetMuscle = "Back/Legs" },
             new Exercise { Id = 11, Name = "Pull-Ups", TargetMuscle = "Back" },
             new Exercise { Id = 12, Name = "Lat Pulldown", TargetMuscle = "Back" },
             new Exercise { Id = 13, Name = "Bent Over Row", TargetMuscle = "Back" },
             new Exercise { Id = 14, Name = "Barbell Curl", TargetMuscle = "Biceps" },
             new Exercise { Id = 15, Name = "Triceps Pushdown", TargetMuscle = "Triceps" }
             );


        }
















    }
}
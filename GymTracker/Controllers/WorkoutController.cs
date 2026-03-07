using System.Security.Claims;
using GymTracker.Data;
using GymTracker.Models;
using GymTracker.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GymTracker.Controllers
{
    
    [Authorize]
    public class WorkoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public WorkoutController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var user = await _userManager.GetUserAsync(User);

            
            var myWorkouts = await _context.WorkoutTemplates
                .Where(w => w.AppUserId == user.Id)
                .ToListAsync();

            
            return View(myWorkouts);
        }


        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateWorkoutViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = await _userManager.GetUserAsync(User);

                var newTemplate = new WorkoutTemplate
                {
                    Name = model.Name,
                    AppUserId = user.Id
                };

                _context.WorkoutTemplates.Add(newTemplate);
                await _context.SaveChangesAsync();

                return RedirectToAction("AddExercises", new { id = newTemplate.Id });

            }
            return View(model);
        }

        // TODO: Creating the get and post methods for Create Exercise

        [HttpGet]
        public IActionResult AddExercises(int id)
        {

            var allExercises = _context.exercises.ToList();

            var viewModel = new AddExerciseViewModel
            {

                WorkoutTemplateId = id,

                AvailableExercises = allExercises.Select(e => new SelectListItem
                {
                    Value = e.Id.ToString(),
                    Text = e.Name + " (" + e.TargetMuscle + ")"
                }).ToList()


            };

            return View(viewModel);

        }

        
        [HttpPost]
        public async Task<IActionResult> AddExercises(AddExerciseViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                int currentExerciseCount = _context.ExerciseTemplates
                    .Where(et => et.WorkoutTemplateID == model.WorkoutTemplateId)
                    .Count();

                
                var newExerciseTemplate = new ExerciseTemplate
                {
                    WorkoutTemplateID = model.WorkoutTemplateId,
                    ExerciseID = model.SelectedExerciseId,
                    TargetSets = model.TargetSets,
                    OrderSequence = currentExerciseCount + 1
                };

                _context.ExerciseTemplates.Add(newExerciseTemplate);
                await _context.SaveChangesAsync();

                
                return RedirectToAction("AddExercises", new { id = model.WorkoutTemplateId });
            }

           
            model.AvailableExercises = _context.exercises.Select(e => new SelectListItem
            {
                Value = e.Id.ToString(),
                Text = e.Name + " (" + e.TargetMuscle + ")"
            }).ToList();

            return View(model);
        }

        
        
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
           
            var workout = await _context.WorkoutTemplates
                .Include(w => w.ExerciseTemplates)
                    .ThenInclude(et => et.Exercise)
                .FirstOrDefaultAsync(w => w.Id == id);

            if (workout == null)
            {
                return NotFound();
            }

            return View(workout);
        }

        
        [HttpPost]
        public async Task<IActionResult> RemoveExercise(int id)
        {
           
            var exerciseToRemove = await _context.ExerciseTemplates.FindAsync(id);

            if (exerciseToRemove == null)
            {
                return NotFound();
            }

            
            int workoutId = exerciseToRemove.WorkoutTemplateID;

            
            _context.ExerciseTemplates.Remove(exerciseToRemove);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("Edit", new { id = workoutId });
        }

        [HttpPost]
        public async Task<IActionResult> StartSession(int templateId)
        {
            var user = await _userManager.GetUserAsync(User);

            
            var newSession = new WorkoutSession
            {
                WorkoutTemplateId = templateId,
                AppUserId = user.Id,
                DatePerformed = DateOnly.FromDateTime(DateTime.Now)
            };

            _context.WorkoutSessions.Add(newSession);
            await _context.SaveChangesAsync();

            
            return RedirectToAction("LogSession", new { id = newSession.Id });
        }

        [HttpGet]
        public async Task<IActionResult> LogSession(int id)
        {
            
            var session = await _context.WorkoutSessions
                .Include(s => s.WorkoutTemplate)
                    .ThenInclude(wt => wt.ExerciseTemplates)
                        .ThenInclude(et => et.Exercise)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null) return NotFound();

            
            var viewModel = new LogSessionViewModel
            {
                SessionId = session.Id,
                WorkoutName = session.WorkoutTemplate.Name,
                Exercises = session.WorkoutTemplate.ExerciseTemplates
                    .OrderBy(et => et.OrderSequence)
                    .Select(et => new ExerciseLogViewModel
                    {
                        ExerciseId = et.ExerciseID,
                        ExerciseName = et.Exercise.Name,
                        TargetSets = et.TargetSets,
                       
                        Sets = Enumerable.Range(1, et.TargetSets)
                            .Select(_ => new SetEntryViewModel()).ToList()
                    }).ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LogSession(LogSessionViewModel model)
        {

            

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                foreach (var error in errors)
                {
                    Console.WriteLine("VALIDATION ERROR: " + error.ErrorMessage);
                }
                return View(model);
            }
            
            var setRecords = new List<SetRecord>();

           
            foreach (var exercise in model.Exercises)
            {
                
                for (int i = 0; i < exercise.Sets.Count; i++)
                {
                    var setEntry = exercise.Sets[i];

                    
                    
                    {
                        setRecords.Add(new SetRecord
                        {
                            WorkoutSessionId = model.SessionId,
                            ExerciseId = exercise.ExerciseId,
                            SetNumber = i + 1,
                            Weight = setEntry.Weight ?? 0,  // if null, default to 0
                            Reps = setEntry.Reps ?? 0
                        });
                    }
                }
            }

           
            if (setRecords.Any())
            {
                _context.SetRecords.AddRange(setRecords);
                await _context.SaveChangesAsync();
            }

            
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Stats()
        {
           
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                return Challenge(); // Or RedirectToAction("Login", "Account");
            }

          
            var sevenDaysAgo = DateOnly.FromDateTime(DateTime.UtcNow.AddDays(-7));
            
            var volumeData = await _context.SetRecords
                .Include(sr => sr.WorkoutSession)
                .Include(sr => sr.Exercise)
                .Where(sr => sr.WorkoutSession.AppUserId == userId && sr.WorkoutSession.DatePerformed >= sevenDaysAgo)
                .GroupBy(sr => sr.Exercise.TargetMuscle)
                .Select(g => new MuscleVolumeItem
                {
                    MuscleGroup = g.Key,
                    TotalSets = g.Count() 
                })
                .ToListAsync();

            var availableExercises = await _context.SetRecords
                .Include(sr => sr.Exercise)
                .Where(sr => sr.WorkoutSession.AppUserId == userId)
                .Select(sr => sr.Exercise)
                .Distinct()
                .Select(e => new ExerciseDropdownItem
                {
                    Id = e.Id,
                    Name = e.Name
                })
                .OrderBy(e => e.Name)
                .ToListAsync();

           
            var viewModel = new StatsViewModel
            {
                MuscleVolumeData = volumeData,
                AvailableExercises = availableExercises
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetExerciseProgressData(int exerciseId)
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (string.IsNullOrEmpty(userId))
            {
                
                return Unauthorized();
            }

           
            var progressData = await _context.SetRecords
                .Include(sr => sr.WorkoutSession)
                .Where(sr => sr.WorkoutSession.AppUserId == userId && sr.ExerciseId == exerciseId)
                
                .GroupBy(sr => sr.WorkoutSession.DatePerformed)
               
                .OrderBy(g => g.Key)
                .Select(g => new
                {
                    
                    DateString = g.Key.ToString("MMM dd"),

                    
                    TotalVolume = g.Sum(sr => sr.Weight * sr.Reps)
                })
                .ToListAsync();

           
            return Json(progressData);
        }






    }
}
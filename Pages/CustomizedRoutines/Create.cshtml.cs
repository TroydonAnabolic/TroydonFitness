using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.CustomizedRoutines
{
    public class CreateRoutineModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;
        private readonly IWebHostEnvironment _hostingEnv;

        public CreateRoutineModel(TroydonFitness.Data.ProductContext context, IWebHostEnvironment hostingEnv)
        {
            _context = context;
            _hostingEnv = hostingEnv;
        }
        
        // Enums and List Items

        public enum Difficulty
        {
            Beginner, Intermediate, Advanced
        }
        public enum MuscleGroups
        {
            Calves, Quadriceps, Hamstrings, Gluteus, Hips, [Display(Name = "Lower Back")] LowerBack, [Display(Name = "Upper Back")] UpperBack, Abdominals
        }
        public enum Equipment
        {
            Barbell, Dumbbell,
            [Display(Name = "Tread Mill")] TreadMill, [Display(Name = "Spin Bike")] SpinBike, Elliptical, StepMill, [Display(Name = "Rowing Machine")] RowingMachine
        }

        public enum Exercises
        {
            // Calves
            [Display(Name = "---Calves---")]
            CALVES,
            [Display(Name = "Standing Calf Raise")] StandingCalfRaise, [Display(Name = "Seated Calf Raise")] SeatedCalfRaise,
            // Quadriceps
            [Display(Name = "---Quadriceps---")]
            QUADRICEPS,
            Squat, [Display(Name = "Leg Press")] LegPress, Lunge, [Display(Name = "Leg Extension")] LegExtension, [Display(Name = "Single Leg Extension")] SingleLegExtension, [Display(Name = "Hack Squat")] HackSquat,

            // Hamstrings
            [Display(Name = "---Hamstrings---")]
            HAMSTRINGS,
            [Display(Name = "Seated Leg Curl")] SeatedLegCurl, [Display(Name = "Standing Leg Curl")] StandingLegCurl, [Display(Name = "Romanian Deadlift")] RomanianDeadlift,

            // Glutues
            [Display(Name = "---Glutes---")]
            GLUTES,
            [Display(Name = "Glute Ham Raises")] GluteHamRaises, [Display(Name = "Glute Bridge")] GluteBridge, [Display(Name = "Glute Raises")] GluteRaises, [Display(Name = "Glute Kickbacks")] GluteKickbacks,

            // Hips
            [Display(Name = "---Hips---")]
            HIPS,
            [Display(Name = "Hip Adductor")] HipAdductor, [Display(Name = "Hip Abductor")] HipAbductor, [Display(Name = "Leg Raises")] LegRaises,

            // Lower Back
            [Display(Name = "---Lower Back---")]
            LOWERBACK,
            Deadlift, Hyperextension,

            // Lats
            [Display(Name = "---Upper Back---")]
            LATS,
            [Display(Name = "Pull Ups")] PullUps, Rows, [Display(Name = "Pull Down")] PullDown,

            //Abdominals
            [Display(Name = "---Abdominals---")]
            ABDOMINALS,
            Crunches, [Display(Name = "Russian Twist")] RussianTwist,

            // Pectorals
            [Display(Name = "---Pectorals---")]
            PECTORALS,
            [Display(Name = "Bench Press")] BenchPress, [Display(Name = "Chest fly")] ChestFly, [Display(Name = "Push Ups")] PushUps,
            // DELTOIDS
            [Display(Name = "---Deltoids---")]
            DELTOIDS,
            [Display(Name = "Upright Row")] UprightRow, [Display(Name = "Shoulder Press")] ShoulderPress, [Display(Name = "Shoulder Fly")] ShoulderFly, [Display(Name = "Lateral Raise")] LtaeralRaise,

            // Triceps
            [Display(Name = "---Triceps---")]
            TRICEPS,
            Pushdown, [Display(Name = "Tricep Extension")] TricepExtension,

            // Biceps
            [Display(Name = "---Biceps---")]
            BICEPS,
            [Display(Name = "Bicep Curl")] BicepCurl, [Display(Name = "Single Arm Bicep Curl")] SingleArmBicepCurl,

            // Forearms
            [Display(Name = "---Forearms---")]
            FOREARMS,
            [Display(Name = "Forearm Curl")] ForearmCurl, [Display(Name = "Farmers Walk")] FarmerWalk,

            // Trapezius
            [Display(Name = "---Trapezius---")]
            TRAPEZIUS,
            Shrugs,

            // Cardio
            [Display(Name = "---Cardio---")]
            CARDIO,
            Running, Biking, Climbing, Rowing
        }
        // -------------- HTTP GET  HTTP POST------------------------

        public IActionResult OnGet()
        {
        ViewData["ProductID"] = new SelectList(_context.Set<CustomizedRoutine>(), "ProductID", "ProductID");
            return Page();
        }

        [BindProperty]
        public CustomizedRoutineVM CustomizedRoutineVM { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // var emptyRoutine = new CustomizedRoutine();

            //if (await TryUpdateModelAsync<CustomizedRoutine>(
            //    emptyRoutine,
            //    "customizedroutine",   // Prefix for form value.
            //    p => p.ProductID, p => p.RoutineType, p => p.RoutineDescription, p => p.DifficultyLevel, p => p.RoutineAdded,
            //     p => p.Exercise1, p => p.MuscleGroup,  p => p.WorkoutDuration,
            //     p => p.Monday, p => p.Tuesday, p => p.Wednesday, p => p.Thursday, p => p.Friday, p => p.Saturday, p => p.Sunday,
            //     p => p.ImagePath) 
            //     && Image!= null) // check

            if (Image != null)
            {
                // Image file search and add
                var a = _hostingEnv.WebRootPath;
                    var fileName = Path.GetFileName(Image.FileName);
                    var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Products\\Routines", fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await Image.CopyToAsync(fileSteam);
                    }

                // Add to the database
                CustomizedRoutineVM.ImagePath = filePath;
                var routine = _context.Add(new CustomizedRoutine());
                routine.CurrentValues.SetValues(CustomizedRoutineVM);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}

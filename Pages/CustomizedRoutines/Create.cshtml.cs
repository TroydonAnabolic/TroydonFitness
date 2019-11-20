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
using System.Web;

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
            Calves, Quadriceps, Hamstrings, Gluteus, Hips, [Display(Name = "Lower Back")] LowerBack, [Display(Name = "Upper Back")] UpperBack, Abdominals,
            Pectorals, Deltoids, Triceps, Biceps, Forearms, Trapezius,
            // Combo
            [Display(Name = "Legs & Calves")] LegsCalves, [Display(Name = "Chest & Shoulders")] ChestShoulders, [Display(Name = "Back & Trapezius")] BackTrapezius, Arms,
            REST
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

            // Upper Back
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

        [BindProperty]
        public CustomizedRoutineVM CustomizedRoutineVM { get; set; }
        [BindProperty]
        public IFormFile Image { get; set; }

        public List<SelectListItem> Split { get; set; }

        public IActionResult OnGet()
        {
            ViewData["ProductID"] = new SelectList(_context.Set<CustomizedRoutine>(), "ProductID", "ProductID");

            // Add Stretches
            var SixDaySplit = new SelectListGroup { Name = "Six Day Split" };
            var FiveDaySplit = new SelectListGroup { Name = "Five Day Split" };
            var FourDaySpliy = new SelectListGroup { Name = "Four Day Split" };
            var ThreeDaySplit = new SelectListGroup { Name = "Three Day Split" };

            Split = new List<SelectListItem>
            {
                new SelectListItem{ Value = "1", Text = "Calves", Group = SixDaySplit},
                new SelectListItem{ Value = "2", Text = "Quadriceps", Group = SixDaySplit},
                new SelectListItem{ Value = "3", Text = "Hamstrings", Group = SixDaySplit}, 
                new SelectListItem{ Value = "4", Text = "Hips", Group = SixDaySplit},
                new SelectListItem{ Value = "5", Text = "Lower Back", Group = SixDaySplit},
                new SelectListItem{ Value = "6", Text = "Upper Back", Group = SixDaySplit},
                new SelectListItem{ Value = "7", Text = "Abdominals", Group = SixDaySplit},
                new SelectListItem{ Value = "8", Text = "Pectorals", Group = SixDaySplit},
                new SelectListItem{ Value = "9", Text = "Deltoids", Group = SixDaySplit},
                new SelectListItem{ Value = "10", Text = "Triceps", Group = SixDaySplit},
                new SelectListItem{ Value = "11", Text = "Biceps", Group = SixDaySplit},
                new SelectListItem{ Value = "12", Text = "Forearms", Group = SixDaySplit},
                new SelectListItem{ Value = "13", Text = "Upper Back", Group = SixDaySplit},
                new SelectListItem{ Value = "14", Text = "Trapezius", Group = SixDaySplit},
                new SelectListItem{ Value = "15", Text = "Back", Group = SixDaySplit},
                new SelectListItem{ Value = "16", Text = "Legs", Group = SixDaySplit},
                new SelectListItem{ Value = "17", Text = "Legs & Calves", Group = SixDaySplit},
                new SelectListItem{ Value = "18", Text = "Deltoids & Trapezius", Group = SixDaySplit},
                new SelectListItem{ Value = "19", Text = "Arms & Abs", Group = SixDaySplit},

                new SelectListItem{ Value = "20", Text = "Chest", Group = FiveDaySplit},
                new SelectListItem{ Value = "21", Text = "Legs & Calves", Group = FiveDaySplit},
                new SelectListItem{ Value = "22", Text = "Deltoids & Abs", Group = FiveDaySplit},
                new SelectListItem{ Value = "23", Text = "Back & Traps", Group = FiveDaySplit},
                new SelectListItem{ Value = "24", Text = "Arms, Abs & Calves", Group = FiveDaySplit},

                new SelectListItem{ Value = "25", Text = "Legs & Calves", Group = FourDaySpliy},
                new SelectListItem{ Value = "26", Text = "Chest, Shoulders & Abs", Group = FourDaySpliy},
                new SelectListItem{ Value = "27", Text = "Back & Trapezius", Group = FourDaySpliy},
                new SelectListItem{ Value = "28", Text = "Arms, Calves & Abs", Group = FourDaySpliy},

                new SelectListItem{ Value = "29", Text = "Upper Body", Group = ThreeDaySplit},
                new SelectListItem{ Value = "30", Text = "Lower Body", Group = ThreeDaySplit},
                new SelectListItem{ Value = "31", Text = "Full Body", Group = ThreeDaySplit},
                new SelectListItem{ Value = "32", Text = "Rest Day", Group = ThreeDaySplit}
            };

            return Page();
        }

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
                var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Products\\Routines\\", fileName);
                //try path map as @"Products\" or Server.MapPath(@"/Routines") "images\\Products\\Routines"
                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await Image.CopyToAsync(fileSteam);
                }

                //// Image file search and add
                //var a = _hostingEnv.WebRootPath;
                //var fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                //var filePath = System.Web.HttpContext.Current.Server.MapPath("~/images/Products/Routines/" + fileName);
                ////try path map as @"Products\" or Server.MapPath(@"/Routines") "images\\Products\\Routines"
                //using (var fileSteam = new FileStream(filePath, FileMode.Create))
                //{
                //    await Image.CopyToAsync(fileSteam);
                //}


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

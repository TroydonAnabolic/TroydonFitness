using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
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

        public enum Difficulty
        {
            Beginner,
            Intermediate,
            Advanced
        }

        public IActionResult OnGet()
        {
        ViewData["Id"] = new SelectList(_context.Set<CustomizedRoutine>(), "Id", "Id");
            return Page();
        }

        [BindProperty]
        public CustomizedRoutine CustomizedRoutine { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

                var emptyRoutine = new CustomizedRoutine();

            if (await TryUpdateModelAsync<CustomizedRoutine>(
                emptyRoutine,
                "customizedroutine",   // Prefix for form value.
                p => p.ProductID, p => p.RoutineType, p => p.RoutineDescription, p => p.DifficultyLevel, p => p.RoutineAdded,
                 p => p.Exercise, p => p.MuscleGroup, p => p.Equipment, p => p.WorkoutDuration, p => p.Sets, p => p.Reps,
                 p => p.Rest, p => p.DayOfTheWeek, p => p.ImagePath) 
                 && CustomizedRoutine.Image!= null) // check
            {
                    // Image file search and add
                    var a = _hostingEnv.WebRootPath;
                    var fileName = Path.GetFileName(CustomizedRoutine.Image.FileName);
                    var filePath = Path.Combine(_hostingEnv.WebRootPath, "images\\Products\\Routines", fileName);

                    using (var fileSteam = new FileStream(filePath, FileMode.Create))
                    {
                        await CustomizedRoutine.Image.CopyToAsync(fileSteam);
                    }

                // Add the remaining data
                CustomizedRoutine.ImagePath = filePath;
                _context.CustomizedRoutines.Add(emptyRoutine);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}

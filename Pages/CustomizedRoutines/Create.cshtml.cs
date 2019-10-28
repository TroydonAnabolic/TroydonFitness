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

                var emptyRoutine = new CustomizedRoutine();

            if (await TryUpdateModelAsync<CustomizedRoutine>(
                emptyRoutine,
                "customizedroutine",   // Prefix for form value.
                p => p.ProductID, p => p.RoutineType, p => p.RoutineDescription, p => p.DifficultyLevel, p => p.RoutineAdded,
                 p => p.Exercise1, p => p.MuscleGroup,  p => p.WorkoutDuration,
                 p => p.Monday, p => p.Tuesday, p => p.Wednesday, p => p.Thursday, p => p.Friday, p => p.Saturday, p => p.Sunday,
                 p => p.ImagePath) 
                 && Image!= null) // check
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
                CustomizedRoutine.ImagePath = filePath;
                _context.CustomizedRoutines.Add(emptyRoutine);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}

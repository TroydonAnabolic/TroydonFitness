using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.CustomizedRoutines
{
    public class RoutineDetailsModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public RoutineDetailsModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CustomizedRoutine CustomizedRoutine { get; set; }
        [BindProperty]
        public CustomizedRoutineVM CustomizedRoutineVM { get; set; }


        public List<SelectListItem> Split { get; set; }



        public FileResult ServeImage(string path)
        {
            var bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "image/jpg");
        }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //Product = await _context.Products
            //    .Include(p => p.PersonalTrainingSessions).FirstOrDefaultAsync(m => m.ProductID == id);

            CustomizedRoutine = await _context.CustomizedRoutines
                .Include(pt => pt.Product)

                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ProductID == id);


            if (CustomizedRoutine == null)
            {
                return NotFound();
            }
            return Page();

        }
    }
}

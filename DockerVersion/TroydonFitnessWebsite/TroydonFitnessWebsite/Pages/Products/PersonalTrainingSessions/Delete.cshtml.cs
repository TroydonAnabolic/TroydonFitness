using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
{
    public class DeleteModel : PageModel
    {
        private readonly Data.ProductContext _context;

        public DeleteModel(Data.ProductContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PersonalTraining PersonalTraining { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTraining = await _context.PersonalTrainingSessions
                .AsNoTracking()
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.PersonalTrainingID == id);

            if (PersonalTraining == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTraining = await _context.PersonalTrainingSessions.FindAsync(id);

            if (PersonalTraining != null)
            {
                _context.PersonalTrainingSessions.Remove(PersonalTraining);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

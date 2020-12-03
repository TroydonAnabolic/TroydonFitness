using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.TrainingRoutines
{
    [Authorize(Policy = "ElevatedRights")]
    public class CreateModel : FilterSortModel
    {
        private readonly Data.ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public CreateModel(
            Data.ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // list of product titles loaded from DB to be used 
        [BindProperty]
        public IEnumerable<PersonalTraining> displayPersonalTrainingNames { get; set; }
        // this value will be set on the select list item and is equal to the producttitle ID of the product title we are looking for
        [BindProperty]
        public int getIndexOfPt { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // gets the logged in user
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (user.IsMasterAdmin)
            {
                PopulateProductDropDownList(_context);
                displayPersonalTrainingNames = await _context.PersonalTrainingSessions.ToListAsync();

                return Page();

            }
            else return RedirectToPage("/Index");
        }

        [BindProperty]
        public TrainingRoutineVM TrainingRoutineVM { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            // display the available select list items

            var emptyPtSession = new TrainingRoutine();
            displayPersonalTrainingNames = await _context.PersonalTrainingSessions.ToListAsync();

            var entry = _context.Add(emptyPtSession);

            // this is the line that can manually set values of the pt name, searches the products, when the prod id == the index assigned, we get the first item, thats a title, and convert to string
            // this bascially gets the ID number of what is selected from the select list on personal training.
            TrainingRoutineVM.RoutineName = displayPersonalTrainingNames.Where(a => a.PersonalTrainingID == getIndexOfPt).FirstOrDefault().PersonalTrainingName.ToString();
            TrainingRoutineVM.PersonalTrainingID = displayPersonalTrainingNames.Where(a => a.PersonalTrainingID == getIndexOfPt).FirstOrDefault().PersonalTrainingID;


            entry.CurrentValues.SetValues(TrainingRoutineVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, emptyPtSession.PersonalTrainingSession.PersonalTrainingName);

            return RedirectToPage("./Index");
        }
    }
}

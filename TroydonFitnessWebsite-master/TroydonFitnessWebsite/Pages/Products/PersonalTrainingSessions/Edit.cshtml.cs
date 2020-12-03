using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
{
    public class EditModel : FilterSortModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public EditModel(
            ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)

        {
            _context = context;
            _userManager = userManager;
        }

        [BindProperty]
        public PersonalTraining PersonalTraining { get; set; }

        [BindProperty]
        public PersonalTrainingVM PersonalTrainingVM { get; set; }
        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTraining = await _context.PersonalTrainingSessions
                .Include(p => p.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.PersonalTrainingID == id);

            // display default value if we are viewing the default training module from db
            if (PersonalTraining == default(PersonalTraining))
            {
                PersonalTrainingVM = new PersonalTrainingVM
                {
                    PersonalTrainingID = PersonalTraining.PersonalTrainingID,
                    ProductID = PersonalTraining.ProductID,
                    LengthOfRoutine = 30,
                    PTSessionType = 0,
                    ExperienceLevel = 0,
                    Description = string.Empty,
                };
            }
            // otherwise show the current values
            else
            {
                PersonalTrainingVM = new PersonalTrainingVM
                {
                    PersonalTrainingID = PersonalTraining.PersonalTrainingID,
                    ProductID = PersonalTraining.ProductID,
                    Description = PersonalTraining.Description,
                    LengthOfRoutine = PersonalTraining.LengthOfRoutine,
                    ExperienceLevel = (PersonalTrainingVM.Difficulty)PersonalTraining.ExperienceLevel,
                    PTSessionType = (PersonalTrainingVM.SessionType)PersonalTraining.PTSessionType,
                    PtProductPicture = PersonalTraining.PtProductPicture,
                };
            }

            if (PersonalTraining == null)
            {
                return NotFound();
            }
            //ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID");
            PopulateProductDropDownList(_context, PersonalTraining.ProductID);

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var ptSessionToUpdate = await _context.PersonalTrainingSessions.FindAsync(id);

        //    if (ptSessionToUpdate == null)
        //    {
        //        return NotFound();
        //    }

        //    if (await TryUpdateModelAsync<PersonalTraining>(
        //         ptSessionToUpdate,
        //         "personaltraining",   // Prefix for form value.
        //            s => s.PersonalTrainingID, s => s.ProductID, 
        //            s => s.LengthOfRoutine, s => s.PTSessionType, s => s.ExperienceLevel, s => s.PtProductPicture))
        //    {
        //        PersonalTraining.LengthOfRoutine = 5;
        //        // add product picture
        //        if (Request.Form.Files.Count > 0)
        //        {
        //            IFormFile file = Request.Form.Files.FirstOrDefault();
        //            using (var dataStream = new MemoryStream())
        //            {
        //                await file.CopyToAsync(dataStream);
        //                PersonalTraining.PtProductPicture = dataStream.ToArray();
        //            }
        //        }

        //        PersonalTraining.CurrentValues.SetValues(PersonalTraining);


        //        await _context.SaveChangesAsync();
        //        return RedirectToPage("./Index");
        //    }

        //    // Select ProductID if TryUpdateModelAsync fails.
        //    PopulateProductDropDownList(_context, ptSessionToUpdate.ProductID);

        //    return Page();
        //}

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PersonalTraining ptSessionToUpdate = await _context.PersonalTrainingSessions.FindAsync(id);

            if (ptSessionToUpdate == null)
            {
                return NotFound();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToPage("/Account/Manage/Login");
            }

           // var emptyPtSession = new PersonalTraining();

          //  var entry = _context.Add(ptSessionToUpdate);

            // add product picture
            if (Request.Form.Files.Count > 0)
            {
                IFormFile file = Request.Form.Files.FirstOrDefault();
                using (var dataStream = new MemoryStream())
                {
                    await file.CopyToAsync(dataStream);
                    PersonalTrainingVM.PtProductPicture = dataStream.ToArray();
                }
            }

            // save the value retrieved from VM to be the value in db
            ptSessionToUpdate.PtProductPicture = PersonalTrainingVM.PtProductPicture;
            ptSessionToUpdate.LengthOfRoutine = PersonalTrainingVM.LengthOfRoutine;

            // entry.CurrentValues.SetValues(PersonalTrainingVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, ptSessionToUpdate.ProductID);


            return RedirectToPage("./Index");
        }




        private bool PersonalTrainingExists(int id)
        {
            return _context.PersonalTrainingSessions.Any(e => e.PersonalTrainingID == id);
        }
    }
}

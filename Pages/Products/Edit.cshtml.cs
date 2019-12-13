using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public EditModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }
        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        [BindProperty]
        public Product Product { get; set; }
        // Replace ViewData["InstructorID"] 
        public SelectList DietNameSL { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Product = await _context.Products
                .Include(p => p.Diets).
                FirstOrDefaultAsync(m => m.ProductID == id);

            if (Product == null)
            {
                return NotFound();
            }
           //ViewData["PersonalTrainingId"] = new SelectList(_context.Set<PersonalTraining>(), "PersonalTrainingID", "PersonalTrainingID");
            // Use strongly typed data rather than ViewData.
            DietNameSL = new SelectList(_context.Diets,
                "DietID", "DietType");

            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            var productToUpdate = await _context.Products
                .Include(i => i.Diets)
                .Include(i => i.PersonalTrainingSessions)
                .FirstOrDefaultAsync(m => m.ProductID == id);

            if (productToUpdate == null)
            {
                return HandleDeletedProduct();
            }

            _context.Entry(productToUpdate)
               .Property("RowVersion").OriginalValue = Product.RowVersion;

            if (await TryUpdateModelAsync<Product>(
                productToUpdate,
                "product",
                p => p.Title, p => p.Description, p => p.Price,
                p => p.Quantity, p => p.HasStock, p => p.ProductAdded))
            {
                try
                {
                    await _context.SaveChangesAsync();
                    return RedirectToPage("./Index");
                }
                catch (DbUpdateConcurrencyException ex) // Implement concurrency exception error if table updated by another
                {
                    var exceptionEntry = ex.Entries.Single();
                    var clientValues = (Product)exceptionEntry.Entity;
                    var databaseEntry = exceptionEntry.GetDatabaseValues();
                    if (databaseEntry == null)
                    {
                        ModelState.AddModelError(string.Empty, "Unable to save. " +
                            "The department was deleted by another user.");
                        return Page();
                    }

                    var dbValues = (Product)databaseEntry.ToObject();
                    await setDbErrorMessage(dbValues, clientValues, _context);

                    // Save the current RowVersion so next postback
                    // matches unless an new concurrency issue happens.
                    Product.RowVersion = (byte[])dbValues.RowVersion;
                    // Clear the model error for the next postback.
                    ModelState.Remove("Product.RowVersion");
                }
            }

            DietNameSL = new SelectList(_context.Diets,
                "DietID", "DietType", productToUpdate.DietID);

            return Page();
        }

        private IActionResult HandleDeletedProduct()
        {
            var deletedProduct = new Product();
            // ModelState contains the posted data because of the deletion error
            // and will overide the Department instance values when displaying Page().
            ModelState.AddModelError(string.Empty,
                "Unable to save. The department was deleted by another user.");
            DietNameSL = new SelectList(_context.Diets, "DietID", "DietType", Product.DietID);
            return Page();
        }
        private async Task setDbErrorMessage(Product dbValues, Product clientValues, ProductContext context)
        {

            if (dbValues.Title != clientValues.Title)
            {
                ModelState.AddModelError("Product.Title",
                    $"Current value: {dbValues.Title}");
            }
            if (dbValues.Price != clientValues.Price)
            {
                ModelState.AddModelError("Product.Price",
                    $"Current value: {dbValues.Price:c}");
            }
            if (dbValues.ProductAdded != clientValues.ProductAdded)
            {
                ModelState.AddModelError("Product.ProductAdded",
                    $"Current value: {dbValues.ProductAdded:d}");
            }
            if (dbValues.DietID != clientValues.DietID)
            {
                Diet dbDiet = await _context.Diets
                   .FindAsync(dbValues.DietID);
                ModelState.AddModelError("Product.DietID",
                    $"Current value: {dbDiet?.DietWeight}");
            }

            ModelState.AddModelError(string.Empty,
                "The record you attempted to edit "
              + "was modified by another user after you. The "
              + "edit operation was canceled and the current values in the database "
              + "have been displayed. If you still want to edit this record, click "
              + "the Save button again.");
        }
    }
}

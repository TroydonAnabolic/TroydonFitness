using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.Diets
{
    public class IndexModel : FilterSortModel
    {
        private readonly ProductContext _context;

        public IndexModel(ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)

        {
            _context = context;
        }

        // Create a paginated List page of type diet to allow paging
        public PaginatedList<Diet> Diets { get; set; }
        // set these prop values from page if possible
        [BindProperty]
        public string Allergies { get; set; }
        [BindProperty]
        public string PreferredFood { get; set; }


        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            PopulateProductDropDownList(_context); // add option to populate and view data to which routine we are adding

            // assign hard prefix values
            AssigningSortOrderValues(sortOrder);

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            // assigning props to allow retention on sort and search string as we page through the products
            CurrentFilter = searchString;
            CurrentSort = sortOrder;

            // The method uses LINQ to Entities to specify the column to sort by. The code initializes an IQueryable<Student> before the switch statement, and modifies it in the switch statement:
            IQueryable<Diet> dietsIQ = from s in _context.Diets
                                       select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                // TODO: Add options to be able to search by product ID, search by price, availability, and updated, remove the .ToUpper() when we use SQL Server instead of SQL Lite
                dietsIQ = dietsIQ.Where(d => d.PersonalTrainingSession.Product.Title.Contains(searchString.ToUpper()) ||
                d.PersonalTrainingSession.Product.ShortDescription.Contains(searchString.ToUpper())
                || d.Description.Contains(searchString.ToUpper()));
            }

            dietsIQ = (IQueryable<Diet>)DetermineSortOrder(sortOrder, dietsIQ);

            int pageSize = 5;

            Diets = await PaginatedList<Diet>.CreateAsync(
               dietsIQ
               .Include(tr => tr.PersonalTrainingSession.Product) // include querys ensure we are gathering data from the database.
               .ThenInclude(tr => tr.PersonalTrainingSessions)
               //.AsNoTracking()
               , pageIndex ?? 1, pageSize);
        }

        // Gather values to create a diet order
        [BindProperty]
        public OrderVM OrderVM { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var emptyOrder = new Order();

            var entry = _context.Add(emptyOrder);
            entry.CurrentValues.SetValues(OrderVM);
            await _context.SaveChangesAsync();

            PopulateProductDropDownList(_context, emptyOrder.DietID);

            return RedirectToPage("/Products/Orders/ViewOrders");
        }

        // Custom methods for determining what will be sorted
        private static IQueryable DetermineSortOrder(string sortOrder, IQueryable<Diet> dietsIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    dietsIQ = dietsIQ.OrderBy(s => s.PersonalTrainingSession.ProductID);
                    break;
                case "id_sort_desc":
                    dietsIQ = dietsIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID);
                    break;
                case "dietID":
                    dietsIQ = dietsIQ.OrderBy(s => s.DietID);
                    break;
                case "dietID_desc":
                    dietsIQ = dietsIQ.OrderByDescending(s => s.DietID);
                    break;
                case "ptID":
                    dietsIQ = dietsIQ.OrderBy(s => s.PersonalTrainingID);
                    break;
                case "ptID_desc":
                    dietsIQ = dietsIQ.OrderByDescending(s => s.PersonalTrainingID);
                    break;
                case "Price":
                    dietsIQ = dietsIQ.OrderBy(s => s.PersonalTrainingSession.Product.Price);
                    break;
                case "price_desc":
                    dietsIQ = dietsIQ.OrderByDescending(s => s.PersonalTrainingSession.Product.Price);
                    break;
                case "Length":
                    dietsIQ = dietsIQ.OrderBy(s => s.PersonalTrainingSession.LengthOfRoutine);
                    break;
                case "length_desc":
                    dietsIQ = dietsIQ.OrderByDescending(s => s.PersonalTrainingSession.LengthOfRoutine);
                    break;
                default:
                    dietsIQ = dietsIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID); // on page load it displays the last product added first
                    break;
            }
            return dietsIQ;
        }
    }
}

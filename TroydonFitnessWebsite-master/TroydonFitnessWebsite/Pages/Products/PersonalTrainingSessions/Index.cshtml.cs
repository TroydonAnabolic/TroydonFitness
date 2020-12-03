using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.PersonalTrainingSessions
{
    [Authorize(Policy = "ElevatedRights")]
    public class IndexModel : FilterSortModel
    {
        private readonly Data.ProductContext _context;

        public IndexModel(Data.ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
        }

        public PaginatedList<PersonalTraining> PersonalTrainingSessions { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
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
            IQueryable<PersonalTraining> ptSessionsIQ = from s in _context.PersonalTrainingSessions
                                                        select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                // TODO: Add options to be able to search by product ID, search by price, availability, and updated, remove the .ToUpper() when we use SQL Server instead of SQL Lite
                ptSessionsIQ = ptSessionsIQ.Where(pt => pt.Product.Title.Contains(searchString.ToUpper()) || pt.Product.ShortDescription.Contains(searchString.ToUpper())
                || pt.Description.Contains(searchString.ToUpper()));
            }

            ptSessionsIQ = DetermineSortOrder(sortOrder, ptSessionsIQ);

            int pageSize = 5;

            PersonalTrainingSessions = await PaginatedList<PersonalTraining>.CreateAsync(
               ptSessionsIQ
               .Include(pt => pt.Product)
               .AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        private static IQueryable<PersonalTraining> DetermineSortOrder(string sortOrder, IQueryable<PersonalTraining> ptSessionsIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    ptSessionsIQ = ptSessionsIQ.OrderBy(s => s.ProductID);
                    break;
                case "id_sort_desc":
                    ptSessionsIQ = ptSessionsIQ.OrderByDescending(s => s.ProductID);
                    break;
                case "ptID":
                    ptSessionsIQ = ptSessionsIQ.OrderBy(s => s.PersonalTrainingID);
                    break;
                case "ptID_desc":
                    ptSessionsIQ = ptSessionsIQ.OrderByDescending(s => s.PersonalTrainingID);
                    break;
                case "Title":
                    ptSessionsIQ = ptSessionsIQ.OrderBy(s => s.Product.Title);
                    break;
                case "title_desc":
                    ptSessionsIQ = ptSessionsIQ.OrderByDescending(s => s.Product.Title);
                    break;
                case "Length":
                    ptSessionsIQ = ptSessionsIQ.OrderBy(s => s.LengthOfRoutine);
                    break;
                case "length_desc":
                    ptSessionsIQ = ptSessionsIQ.OrderByDescending(s => s.LengthOfRoutine);
                    break;
                default:
                    ptSessionsIQ = ptSessionsIQ.OrderByDescending(s => s.ProductID); // on page load it displays the last product added first
                    break;
            }

            return ptSessionsIQ;
        }
    }
}

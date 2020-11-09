using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Areas.Identity.Data.Authorization;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products
{
    [Authorize(Policy = "ElevatedRights")]
    public class IndexModel : FilterSortModel
    {
        private readonly ProductContext _context;

        public IndexModel(
            ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
        }

        public PaginatedList<Product> Products { get; set; }

        // later change to generic type so we can filter dates and ints with same varible?
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
            IQueryable<Product> productsIQ = from s in _context.Products
                                             select s;

            // var currentUserId = UserManager.GetUserId(User);

            // Only approved contacts are shown UNLESS you're authorized to see them

                if (!String.IsNullOrEmpty(searchString))
                {
                    // TODO: Add options to be able to search by product ID, search by price, availability, and updated, remove the .ToUpper() when we use SQL Server instead of SQL Lite
                    productsIQ = productsIQ.Where(s => s.Title.Contains(searchString.ToUpper()) || s.ShortDescription.Contains(searchString.ToUpper()));
                }

                productsIQ = DetermineSortOrder(sortOrder, productsIQ);

            int pageSize = 5;


            Products = await PaginatedList<Product>.CreateAsync(
            productsIQ
            .Include(pt => pt.PersonalTrainingSessions)
            .ThenInclude(tr => tr.TrainingRoutine)
            .AsNoTracking(), pageIndex ?? 1, pageSize);
            // The query isn't executed until the IQueryable object is converted into a collection. IQueryable are converted to a collection by calling a method such as ToListAsync.
        }

        private static IQueryable<Product> DetermineSortOrder(string sortOrder, IQueryable<Product> productsIQ)
        {
            switch (sortOrder)
            {
                case "Title":
                    productsIQ = productsIQ.OrderBy(s => s.Title);
                    break;
                case "title_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.Title);
                    break;
                case "Price":
                    productsIQ = productsIQ.OrderBy(s => s.Price);
                    break;
                case "price_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.Price);
                    break;
                case "Quantity":
                    productsIQ = productsIQ.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.Quantity);
                    break;
                case "Date":
                    productsIQ = productsIQ.OrderBy(s => s.LastUpdated);
                    break;
                case "date_desc":
                    productsIQ = productsIQ.OrderByDescending(s => s.LastUpdated);
                    break;
                default:
                    productsIQ = productsIQ.OrderByDescending(s => s.ProductID); // on page load it displays the last product added first
                    break;
            }

            return productsIQ;
        }
    }
}

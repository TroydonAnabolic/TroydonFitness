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

namespace TroydonFitnessWebsite.Pages.Products.Supplements
{
    public class IndexModel : FilterSortModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public IndexModel(
            ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)

        {
            _context = context;
            _userManager = userManager;
        }

        public PaginatedList<Supplement> Supplements { get; set; }


        public async Task<IActionResult> OnGetAsync(string sortOrder,
    string currentFilter, string searchString, int? pageIndex)
        {
            PopulateProductDropDownList(_context); // add option to populate and view data to which supplement we are adding

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
            var user = await _userManager.GetUserAsync(HttpContext.User);

            // assigning props to allow retention on sort and search string as we page through the products
            CurrentFilter = searchString;
            CurrentSort = sortOrder;

            // The method uses LINQ to Entities to specify the column to sort by. The code initializes an IQueryable<Student> before the switch statement, and modifies it in the switch statement:
            IQueryable<Supplement> supplementIQ = from s in _context.Supplements
                                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                // TODO: Add options to be able to search by product ID, search by price, availability, and updated, remove the .ToUpper() when we use SQL Server instead of SQL Lite
                supplementIQ = supplementIQ.Where(tr => tr.Product.Title.Contains(searchString.ToUpper()) ||
                tr.Product.ShortDescription.Contains(searchString.ToUpper())
               );
            }

            supplementIQ = (IQueryable<Supplement>)DetermineSortOrder(sortOrder, supplementIQ);

            int pageSize = 5;

            Supplements = await PaginatedList<Supplement>.CreateAsync(
               supplementIQ
               .Include(tr => tr.Product)
               //.AsNoTracking()
               , pageIndex ?? 1, pageSize);

            return Page();
        }

        // Add Postback method here when a new order is required

        [BindProperty]
        public CartVM CartVM { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (user == null)
            {
                return RedirectToPage("/Index"); // TODO: Change to login redirect
            }

            IList<Cart> cartItem = await _context.CartItems.ToListAsync();


            var emptyCartItem = new Cart();

            var entry = _context.Add(emptyCartItem);
            // assign a userID to the order, so we know which cart items to remove
            CartVM.PurchaserID = user.Id;
            // if the user edits the cart to have a value more than 1 then redirect to the same page
            if (CartVM.Quantity > 1) return RedirectToPage("./Index");
            entry.CurrentValues.SetValues(CartVM);
            await _context.SaveChangesAsync();

            var cartItemList = await _context.CartItems
                .Include(t => t.Supplement)
                .ToListAsync();

            PopulateProductDropDownList(_context, emptyCartItem.SupplementID);

            // returns to the list of current orders
            //return RedirectToPage(); <---return to add more if needed
            // return RedirectToPage("./Index"); previous, if go back two directories and to view orders dont work
            return RedirectToPage("/Products/Orders/ManageCart/ViewCart");
        }

        // Custom methods for determining what will be sorted
        private static IQueryable DetermineSortOrder(string sortOrder, IQueryable<Supplement> supplementIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    supplementIQ = supplementIQ.OrderBy(s => s.ProductID);
                    break;
                case "id_sort_desc":
                    supplementIQ = supplementIQ.OrderByDescending(s => s.ProductID);
                    break;
                case "suppID":
                    supplementIQ = supplementIQ.OrderBy(s => s.SupplementID);
                    break;
                case "suppID_desc":
                    supplementIQ = supplementIQ.OrderByDescending(s => s.SupplementID);
                    break;
                case "Price":
                    supplementIQ = supplementIQ.OrderBy(s => s.SupplementPrice);
                    break;
                case "price_desc":
                    supplementIQ = supplementIQ.OrderByDescending(s => s.SupplementPrice);
                    break;
                default:
                    supplementIQ = supplementIQ.OrderByDescending(s => s.ProductID); // on page load it displays the last product added first
                    break;
            }
            return supplementIQ;
        }
    }
}

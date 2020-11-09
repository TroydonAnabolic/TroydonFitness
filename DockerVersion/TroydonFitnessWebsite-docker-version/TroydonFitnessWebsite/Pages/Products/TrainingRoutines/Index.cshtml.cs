using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Models.Products.ViewModels;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.TrainingRoutines
{
    // TODO NEXT: see if we can inherit filter sort model and use it as a universal property provider to sort the same entity data
    [AllowAnonymous]
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
        public PaginatedList<TrainingRoutine> TrainingRoutines { get; set; }


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
                var user = await _userManager.GetUserAsync(HttpContext.User);

            // TODO: if user is signed in then show this e.g if (user != null)
            user.TimeLeft = user.CoolOffDate - DateTime.Now;
           
            // assigning props to allow retention on sort and search string as we page through the products
            CurrentFilter = searchString;
            CurrentSort = sortOrder;

            // The method uses LINQ to Entities to specify the column to sort by. The code initializes an IQueryable<Student> before the switch statement, and modifies it in the switch statement:
            IQueryable<TrainingRoutine> trainingRoutinesIQ = from s in _context.TrainingRoutines
                                                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                // TODO: Add options to be able to search by product ID, search by price, availability, and updated, remove the .ToUpper() when we use SQL Server instead of SQL Lite
                trainingRoutinesIQ = trainingRoutinesIQ.Where(tr => tr.PersonalTrainingSession.Product.Title.Contains(searchString.ToUpper()) ||
                tr.PersonalTrainingSession.Product.ShortDescription.Contains(searchString.ToUpper())
               );
            }

            trainingRoutinesIQ = (IQueryable<TrainingRoutine>)DetermineSortOrder(sortOrder, trainingRoutinesIQ);

            int pageSize = 5;

            TrainingRoutines = await PaginatedList<TrainingRoutine>.CreateAsync(
               trainingRoutinesIQ
               .Include(tr => tr.PersonalTrainingSession.Product)
               .ThenInclude(tr => tr.PersonalTrainingSessions)
               //.AsNoTracking()
               , pageIndex ?? 1, pageSize);
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
                return RedirectToPage("/Account/Manage/Login");
            }

            IList<Cart> cartItem = await _context.CartItems.ToListAsync();

            // if the amount of days passed since order was created can make order is allow user to add to cart, otherwise redirect
            if (user.CoolOffDate <= DateTime.Now)
            {
                var emptyCartItem = new Cart();

                var entry = _context.Add(emptyCartItem);
                // assign a userID to the order, so we know which cart items to remove
                CartVM.PurchaserID = user.Id;
                // if the user edits the cart to have a value more than 1 then redirect to the same page
                if (CartVM.Quantity > 1) return RedirectToPage("./Index");
                entry.CurrentValues.SetValues(CartVM);
                await _context.SaveChangesAsync();

                var cartItemList = await _context.CartItems
                    .Include(t => t.TrainingRoutine)
                    .ThenInclude(p => p.PersonalTrainingSession)
                    .ToListAsync();


                // grab the length of the routine for the newly created order
                int routineLengthChosen = 0;// _context.CartItems.Where(o => o.TrainingRoutineID == CartVM.TrainingRoutineID).OrderByDescending(o => o.CartID).FirstOrDefault().TrainingRoutine.PersonalTrainingSession.LengthOfRoutine;
                routineLengthChosen = cartItemList.OrderByDescending(o => o.CartID).FirstOrDefault().TrainingRoutine.PersonalTrainingSession.LengthOfRoutine;

                // set the cool off date before we can order to be the length of the routine length chosen
                user.CoolOffDate = DateTime.Now.AddDays(routineLengthChosen);
                await _userManager.UpdateAsync(user);

                PopulateProductDropDownList(_context, emptyCartItem.TrainingRoutineID);

                // returns to the list of current orders
                //return RedirectToPage(); <---return to add more if needed
                // return RedirectToPage("./Index"); previous, if go back two directories and to view orders dont work
                return RedirectToPage("/Products/Orders/ManageCart/ViewCart");
            }
            return RedirectToPage("./Index");
        }

        // Custom methods for determining what will be sorted
        private static IQueryable DetermineSortOrder(string sortOrder, IQueryable<TrainingRoutine> trainingRoutinesIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.ProductID);
                    break;
                case "id_sort_desc":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID);
                    break;
                case "trainID":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.TrainingRoutineID);
                    break;
                case "trainID_desc":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.TrainingRoutineID);
                    break;
                case "ptID":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingID);
                    break;
                case "ptID_desc":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingID);
                    break;
                case "Price":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.Product.Price);
                    break;
                case "price_desc":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.Product.Price);
                    break;
                case "Length":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.LengthOfRoutine);
                    break;
                case "length_desc":
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.LengthOfRoutine);
                    break;
                default:
                    trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID); // on page load it displays the last product added first
                    break;
            }
            return trainingRoutinesIQ;
        }
    }
}
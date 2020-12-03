using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.Orders.ManageCart
{
    public class ViewCartModel : FilterSortModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public ViewCartModel(ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)

        {
            _context = context;
            _userManager = userManager;
        }

        public PaginatedList<Cart> CartItems { get; set; }

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

            CurrentFilter = searchString;
            CurrentSort = sortOrder;

            var user = await _userManager.GetUserAsync(HttpContext.User);
            IQueryable<Cart> cartIQ;
            if (!user.IsMasterAdmin) // if it is not a master admin, then you can only view items in your cart
            {
                cartIQ = from s in _context.CartItems
                                          .Where(uniq => uniq.PurchaserID == user.Id)
                                          select s;
            }
            else // master admin can always view cart items from all users
            {
                 cartIQ = from s in _context.CartItems
                                          .Where(uniq => uniq.PurchaserID == user.Id)
                                          select s;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                cartIQ = cartIQ.Where(o => o.TrainingRoutine.PersonalTrainingSession.Product.Title.Contains(searchString.ToUpper()));
            }

            cartIQ = DetermineSortOrder(sortOrder, cartIQ);

            int pageSize = 5;

            // Include related data to be retrieved as required
            CartItems = await PaginatedList<Cart>.CreateAsync(
               cartIQ
               .Include(o => o.Diet)
                    .ThenInclude(pt => pt.PersonalTrainingSession)
                        .ThenInclude(p => p.Product)
                .Include(o => o.Supplement)
                        .ThenInclude(p => p.Product)
                .Include(o => o.TrainingEquipment)
                    .ThenInclude(o => o.Product)
                .Include(o => o.TrainingRoutine)
                    .ThenInclude(pt => pt.PersonalTrainingSession)
                        .ThenInclude(p => p.Product),
               // .Where(o => o.Customer == User.Identity.Name) TODO when we implement identity
               //.AsNoTracking(),
               pageIndex ?? 1, pageSize);
        }

        private static IQueryable<Cart> DetermineSortOrder(string sortOrder, IQueryable<Cart> cartIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    cartIQ = cartIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.ProductID);
                    break;
                case "id_sort_desc":
                    cartIQ = cartIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.ProductID);
                    break;
                case "cartID":
                    cartIQ = cartIQ.OrderBy(s => s.CartID);
                    break;
                case "cartID_desc":
                    cartIQ = cartIQ.OrderByDescending(s => s.CartID);
                    break;
                case "Title":
                    cartIQ = cartIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.Title);
                    break;
                case "title_desc":
                    cartIQ = cartIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.Title);
                    break;
                case "Price":
                    cartIQ = cartIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.Price);
                    break;
                case "price_desc":
                    cartIQ = cartIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.Price);
                    break;
                default:
                    cartIQ = cartIQ.OrderBy(s => s.CartID);
                    break;
            }

            return cartIQ;
        }
    }
}

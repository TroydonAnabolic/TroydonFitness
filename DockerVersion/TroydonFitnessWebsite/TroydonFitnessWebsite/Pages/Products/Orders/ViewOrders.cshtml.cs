using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Pages.CustomisedModel;

namespace TroydonFitnessWebsite.Pages.Products.Orders
{
    public class ViewOrdersModel : FilterSortModel
    {
        private readonly ProductContext _context;
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public ViewOrdersModel(ProductContext context,
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public PaginatedList<Order> Orders { get; set; }

        public async Task OnGetAsync(string sortOrder,
           string currentFilter, string searchString, int? pageIndex)
        {
            var user = await _userManager.GetUserAsync(User);


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

            IQueryable<Order> ordersIQ = from s in _context.Orders
                                         where (s.PurchaserID == user.Id)
                                         select s;


            if (!String.IsNullOrEmpty(searchString))
            {
                ordersIQ = ordersIQ.Where(o => o.TrainingRoutine.PersonalTrainingSession.Product.Title.Contains(searchString.ToUpper()));
            }

            ordersIQ = DetermineSortOrder(sortOrder, ordersIQ);

            int pageSize = 10;

            Orders = await PaginatedList<Order>.CreateAsync(
               ordersIQ
               .Include(o => o.Diet)
                .Include(o => o.Supplement)
                .Include(o => o.TrainingEquipment)
                .Include(o => o.TrainingRoutine)
                    .ThenInclude(pt => pt.PersonalTrainingSession)
                        .ThenInclude(p => p.Product),
               // .Where(o => o.Customer == User.Identity.Name) TODO when we implement identity
               //.AsNoTracking(),
               pageIndex ?? 1, pageSize);
        }

        private static IQueryable<Order> DetermineSortOrder(string sortOrder, IQueryable<Order> ordersIQ)
        {
            switch (sortOrder)
            {
                case "id_sort":
                    ordersIQ = ordersIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.ProductID);
                    break;
                case "id_sort_desc":
                    ordersIQ = ordersIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.ProductID);
                    break;
                case "orderID":
                    ordersIQ = ordersIQ.OrderBy(s => s.OrderID);
                    break;
                case "orderID_desc":
                    ordersIQ = ordersIQ.OrderByDescending(s => s.OrderID);
                    break;
                case "Title":
                    ordersIQ = ordersIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.Title);
                    break;
                case "title_desc":
                    ordersIQ = ordersIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.Title);
                    break;
                case "Price":
                    ordersIQ = ordersIQ.OrderBy(s => s.TrainingRoutine.PersonalTrainingSession.Product.Price);
                    break;
                case "price_desc":
                    ordersIQ = ordersIQ.OrderByDescending(s => s.TrainingRoutine.PersonalTrainingSession.Product.Price);
                    break;
                default:
                    ordersIQ = ordersIQ.OrderBy(s => s.OrderID);
                    break;
            }

            return ordersIQ;
        }
    }
}
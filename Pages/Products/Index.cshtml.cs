using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public IndexModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        // Sort/Filter/Group props
        public string TitleSort { get; set; }
        public string QuantitySort { get; set; }
        public string PriceSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public IList<Product> Products { get;set; }

        public async Task OnGetAsync(string sortOrder)
        {
            // Sorting
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            QuantitySort = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            IQueryable<Product> toSort = from p in _context.Products
                                             select p;

            switch (sortOrder)
            {
                case "title_desc":
                    toSort = toSort.OrderByDescending(s => s.Title);
                    break;
                case "Quantity":
                    toSort = toSort.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    toSort = toSort.OrderByDescending(s => s.Quantity);
                    break;
                case "price_desc":
                    toSort = toSort.OrderByDescending(s => s.Price);
                    break;
                default:
                    toSort = toSort.OrderBy(s => s.Price);
                    break;
            }

            // Load in the products
            Products = await toSort.AsNoTracking()
                .Include(p => p.PersonalTrainingSessions).ToListAsync();
        }
    }
}

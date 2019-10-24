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

        public PaginatedList<Product> Products { get;set; }

        public async Task OnGetAsync(string sortOrder, string searchString,
            string currentFilter, int? pageIndex)
        {
            // Sorting
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            QuantitySort = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Product> productIQ = from p in _context.Products
                                             select p;

            if (!String.IsNullOrEmpty(searchString))
            {
                productIQ = productIQ.Where(s => s.Title.Contains(searchString.ToUpper())
                                       || s.Description.Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "title_desc":
                    productIQ = productIQ.OrderByDescending(s => s.Title);
                    break;
                case "Quantity":
                    productIQ = productIQ.OrderBy(s => s.Quantity);
                    break;
                case "quantity_desc":
                    productIQ = productIQ.OrderByDescending(s => s.Quantity);
                    break;
                case "price_desc":
                    productIQ = productIQ.OrderByDescending(s => s.Price);
                    break;
                default:
                    productIQ = productIQ.OrderBy(s => s.Price);
                    break;
            }

            // Load in the products
            int pageSize = 3;
            Products = await PaginatedList<Product>.CreateAsync(
                productIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.UserAccounts;

namespace TroydonFitnessWebsite.Pages.UserAccount.AdminUser
{
    public class DiagnosticsModel : PageModel
    {
        private readonly ProductContext _context;

        public DiagnosticsModel(ProductContext context)
        {
            _context = context;
        }
        public IList<Diagnostic> Products { get; set; }

        public async Task OnGetAsync()
        {
                IQueryable <Diagnostic> data =
                from product in _context.Products
                group product by product.HasStock into statsGroup
                select new Diagnostic()
                {
                    HasStock = (Models.Products.Product.Availability)statsGroup.Key,
                    ProductCount = statsGroup.Count()
                };

            Products = await data.AsNoTracking().ToListAsync();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.Products.Supplements
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitnessWebsite.Data.ProductContext _context;

        public IndexModel(TroydonFitnessWebsite.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Supplement> Supplement { get;set; }

        public async Task OnGetAsync()
        {
            Supplement = await _context.Supplements
                .Include(s => s.Diet)
                .Include(s => s.Product).ToListAsync();
        }
    }
}

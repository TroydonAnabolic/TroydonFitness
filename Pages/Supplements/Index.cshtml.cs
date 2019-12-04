using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Supplements
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public IndexModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Supplement> Supplements { get;set; }

        public async Task OnGetAsync()
        {
            Supplements = await _context.Supplements
                .Include(c => c.Product) // links the related entity navigation property by explicit loading
                .AsNoTracking()
                .ToListAsync();
        }
    }
}

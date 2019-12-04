using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class IndexModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public IndexModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<Diet> Diet { get;set; }

        public async Task OnGetAsync()
        {
            Diet = await _context.Diets.ToListAsync();
        }
    }
}

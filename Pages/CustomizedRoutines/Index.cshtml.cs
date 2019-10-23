using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.CustomizedRoutines
{
    public class IndexProductModel : PageModel
    {
        private readonly TroydonFitness.Data.ProductContext _context;

        public IndexProductModel(TroydonFitness.Data.ProductContext context)
        {
            _context = context;
        }

        public IList<CustomizedRoutine> CustomizedRoutine { get;set; }

        public async Task OnGetAsync()
        {
            CustomizedRoutine = await _context.CustomizedRoutines
                .Include(p => p.Product).ToListAsync();
        }
    }
}

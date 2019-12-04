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

        public IList<Supplement> Supplements { get; set; }
        public IList<SupplementVM> SupplementVM { get;set; }


        public async Task OnGetAsync()

        {
            SupplementVM = await _context.Supplements
                        .Select(p => new SupplementVM   // load only the data needed
                        { 
                            Id = p.Id,        
                            SupplementAdded = p.SupplementAdded,
                            SupplementType = p.SupplementType,
                            ProductTitle  = p.Product.Title,
                            ProductID = p.Product.ProductID
                        }).ToListAsync();
        }
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.CustomSettings
{
    public class SelectListHelper
    {
        public static IEnumerable<SelectListItem> GetRoutineDuration()
        {
            IList<SelectListItem> items = new List<SelectListItem>
            {
                new SelectListItem{Text = "30 Days", Value = 32.ToString()}, // add 2 days for routine delivery time
                new SelectListItem{Text = "60 Days", Value = 62.ToString()},
                new SelectListItem{Text = "90 Days", Value = 92.ToString()},
            };
            return items;
        }
    }
}

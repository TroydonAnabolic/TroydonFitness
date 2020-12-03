using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Data;

namespace TroydonFitnessWebsite.Pages.CustomisedModel
{
    public class ProductPageModel : PageModel 
    {
        private readonly UserManager<TroydonFitnessWebsiteUser> _userManager;

        public ProductPageModel(UserManager<TroydonFitnessWebsiteUser> userManager)
        {
            _userManager = userManager;
        }

        public SelectList ProductIDSL { get; set; }
        public SelectList TrainingRoutineIDSL { get; set; }
        public SelectList PtIdSL { get; set; }
        public SelectList ProductTitleSL { get; set; }
        public SelectList ProductTitleSL2 { get; set; }
        public SelectList PtNameSL { get; set; }
        public SelectList TrainingRoutineNameSL { get; set; }
        public SelectList RoutineLengthSL { get; set; }
        public SelectList SessionTypeSL { get; set; }
        public SelectList DifficultySL { get; set; }
        public SelectList SupplementIDSL { get; set; }
        public SelectList SupplementNameSL { get; set; }
        public SelectList OrdersSL { get; set; }



        // gather drop down data from related entities
        public void PopulateProductDropDownList(ProductContext _context,
            object selectedTrainingSession = null)
        {
            // Product query string to retrieve data from database and store in product query variable
            var productQuery = from d in _context.Products
                               orderby d.ProductID descending// Sort by name.
                               select d;

            // Pt query string
            // TODO: try limit the amount of things I can select by actually changing this data retrieved from the select list to where only products and pt products have a relationship, then we can create an order that has its product ID in the order
            var ptQuery = from ptProd in _context.PersonalTrainingSessions
                                orderby ptProd.PersonalTrainingID descending// Sort by name.
                                select ptProd; //).SingleOrDefault();

            // training query
            var trainQuery = from d in _context.TrainingRoutines
                          orderby d.PersonalTrainingID descending// Sort by id.
                          select d;

            // supplement query
            var suppQuery = from d in _context.Supplements
                             orderby d.SupplementID descending// Sort by id.
                             select d;

            // orders query
            var orderQuery = from d in _context.Orders
                             orderby d.OrderID descending// Sort by name.
                             select d;

            // prod
            ProductIDSL = new SelectList(productQuery.AsNoTracking(),
                      "ProductID", "ProductID", selectedTrainingSession);

            ProductTitleSL = new SelectList(productQuery.AsNoTracking(),
                        "ProductID", "Title", selectedTrainingSession);

            // pt
            PtIdSL = new SelectList(ptQuery.AsNoTracking(),
                  "PersonalTrainingID", "PersonalTrainingID", selectedTrainingSession);
            RoutineLengthSL = new SelectList(ptQuery.AsNoTracking(),
                  "PersonalTrainingID", "LengthOfRoutine", selectedTrainingSession);
            SessionTypeSL = new SelectList(ptQuery.AsNoTracking(),
                  "PersonalTrainingID", "PTSessionType", selectedTrainingSession);
            DifficultySL = new SelectList(ptQuery.AsNoTracking(),
                  "PersonalTrainingID", "ExperienceLevel", selectedTrainingSession);
            PtNameSL = new SelectList(ptQuery.AsNoTracking(),
                 "PersonalTrainingID", "PersonalTrainingName", selectedTrainingSession);

            // training routine
            TrainingRoutineIDSL = new SelectList(trainQuery.AsNoTracking(),
                "TrainingRoutineID", "TrainingRoutineID", selectedTrainingSession);
            TrainingRoutineNameSL = new SelectList(trainQuery.AsNoTracking(),
               "TrainingRoutineID", "RoutineName", selectedTrainingSession);

            // supplements order
            SupplementIDSL = new SelectList(suppQuery.AsNoTracking(),
                "SupplementID", "SupplementID", selectedTrainingSession);
            SupplementNameSL = new SelectList(suppQuery.AsNoTracking(),
               "SupplementID", "SupplementName", selectedTrainingSession);
        }
    }
}

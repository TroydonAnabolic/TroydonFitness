using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TroydonFitness.Data;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Pages.Diets
{
    public class DietSupplementPageModel : PageModel
    {
        public List<AssignedSupplementData> AssignedSupplementDataList;

        public void PopulateAssignedDietData(ProductContext context,
                                               Diet diet)
        {
            var allSupplements = context.Supplements;
            var instructorCourses = new HashSet<int>(
                diet.SupplementRoutine.Select(c => c.SupplementId));
            AssignedSupplementDataList = new List<AssignedSupplementData>();
            foreach (var supplement in allSupplements)
            {
                AssignedSupplementDataList.Add(new AssignedSupplementData
                {
                    SupplementID = supplement.Id,
                    SupplementTitle = supplement.Product.Title,
                    Assigned = instructorCourses.Contains(supplement.Id)
                });
            }
        }

        public void UpdateInstructorCourses(ProductContext context,
            string[] selectedSupplements, Diet dietToUpdate)
        {
            if (selectedSupplements == null)
            {
                dietToUpdate.SupplementRoutine = new List<SupplementRoutine>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedSupplements);
            var instructorCourses = new HashSet<int>
                (dietToUpdate.SupplementRoutine.Select(c => c.Supplement.Id));
            foreach (var supplement in context.Supplements)
            {
                if (selectedCoursesHS.Contains(supplement.Id.ToString()))
                {
                    if (!instructorCourses.Contains(supplement.Id))
                    {
                        dietToUpdate.SupplementRoutine.Add(
                            new SupplementRoutine
                            {
                             //   CustomizedRoutineId = dietToUpdate.Id, // may have to remove or use customize routine for the full class
                                SupplementId = supplement.Id
                            });
                    }
                }
                else
                {
                    if (instructorCourses.Contains(supplement.Id))
                    {
                        SupplementRoutine suppToRemove
                            = dietToUpdate
                                .SupplementRoutine
                                .SingleOrDefault(i => i.SupplementId == supplement.Id);
                        context.Remove(suppToRemove);
                    }
                }
            }
        }
    }
}

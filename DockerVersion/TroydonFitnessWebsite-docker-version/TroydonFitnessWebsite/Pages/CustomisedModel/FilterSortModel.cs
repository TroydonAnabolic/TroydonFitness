using Microsoft.AspNetCore.Identity;
using System.Linq;
using TroydonFitnessWebsite.Areas.Identity.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Pages.CustomisedModel
{
    public class FilterSortModel : ProductPageModel
    {
        public FilterSortModel(
            UserManager<TroydonFitnessWebsiteUser> userManager) : base(userManager)
        {
        }

        public string IdSort { get; set; }
        public string ptIdSort { get; set; }
        public string DietIdSort { get; set; }
        public string TrainingIdSort { get; set; }
        public string OrderIdSort { get; set; }
        public string CartIdSort { get; set; }
        public string TitleSort { get; set; }
        public string PriceSort { get; set; }
        public string LenghtOfRoutineSort { get; set; }
        public string CustomerNameSort { get; set; }

        public string DateSort { get; set; }
        public string QuantitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public void AssigningSortOrderValues(string sortOrder)
        {
            IdSort = sortOrder == "id_sort" ? "id_sort_desc" : "id_sort";
            ptIdSort = sortOrder == "ptID" ? "ptID_desc" : "ptID";
            TrainingIdSort = sortOrder == "trainID" ? "trainID_desc" : "trainID";
            DietIdSort = sortOrder == "dietID" ? "dietID_desc" : "dietID";
            OrderIdSort = sortOrder == "orderID" ? "orderID_desc" : "orderID";
            CartIdSort = sortOrder == "cartID" ? "cartID_desc" : "cartID";
            TitleSort = sortOrder == "Title" ? "title_desc" : "Title";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            PriceSort = sortOrder == "Price" ? "price_desc" : "Price";
            QuantitySort = sortOrder == "Quantity" ? "quantity_desc" : "Quantity";
            LenghtOfRoutineSort = sortOrder == "Length" ? "length_desc" : "Length";
            CustomerNameSort = sortOrder == "Customer" ? "customer_desc" : "Customer";
        }

        //private static IQueryable DetermineSortOrders(string sortOrder, IQueryable<TrainingRoutine> trainingRoutinesIQ, IQueryable<PersonalTraining> personalTrainingIQ, IQueryable<Order> orderIQ)
        //{
        //    switch (sortOrder)
        //    {
        //        case "id_sort":
        //            // TODO: Ensure try to implement a function so we can apply the sort method depending on what index model is calling the function at any given time
        //            //if (trainingRoutinesIQ)
        //            //    trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.ProductID);
        //            //else if (personalTrainingIQ)
        //            //{
        //            //    personalTrainingIQ = personalTrainingIQ.OrderBy(s => s.ProductID);
        //            //}
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.ProductID);
        //            break;
        //        case "id_sort_desc":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID);
        //            break;
        //        case "trainID":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.TrainingRoutineID);
        //            break;
        //        case "trainID_desc":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.TrainingRoutineID);
        //            break;
        //        case "ptID":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingID);
        //            break;
        //        case "ptID_desc":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingID);
        //            break;
        //        case "Price":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.Product.Price);
        //            break;
        //        case "price_desc":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.Product.Price);
        //            break;
        //        case "Length":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderBy(s => s.PersonalTrainingSession.LengthOfRoutine);
        //            break;
        //        case "length_desc":
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.LengthOfRoutine);
        //            break;
        //        default:
        //            trainingRoutinesIQ = trainingRoutinesIQ.OrderByDescending(s => s.PersonalTrainingSession.ProductID); // on page load it displays the last product added first
        //            break;
        //    }

        //    return trainingRoutinesIQ;
        //}
    }
}

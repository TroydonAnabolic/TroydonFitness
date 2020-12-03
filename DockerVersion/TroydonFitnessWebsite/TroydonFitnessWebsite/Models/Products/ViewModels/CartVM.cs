using System.ComponentModel.DataAnnotations;

namespace TroydonFitnessWebsite.Models.Products.ViewModels
{
    public class CartVM
    {
        public int? TrainingRoutineID { get; set; }
        public int? DietID { get; set; }
        public int? SupplementID { get; set; }
        public int? TrainingEquipmentID { get; set; }
        public string PurchaserID { get; set; }

        // Order Details
        [Display(Name = "Product Name")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        // Navigation properties of all the potential orders details we can have
        public TrainingRoutine TrainingRoutine { get; set; }
        public Diet Diet { get; set; }
        public Supplement Supplement { get; set; }
        public TrainingEquipment TrainingEquipment { get; set; }
        public Order Order { get; set; }
    }
}

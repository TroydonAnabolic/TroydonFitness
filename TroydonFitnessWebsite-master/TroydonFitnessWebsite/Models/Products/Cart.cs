using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Models.Products
{
    public class Cart
    {
        // PK
        public int CartID { get; set; }
        // Optional FKs, it means that orders can have one or none of these
        public int? TrainingRoutineID { get; set; }
        public int? DietID { get; set; }
        public int? SupplementID { get; set; }
        public int? TrainingEquipmentID { get; set; }
        public string PurchaserID { get; set; }
        public int? OrderID { get; set; }


        // Navigation properties of all the potential orders details we can have
        public Product Product { get; set; }

        public TrainingRoutine TrainingRoutine { get; set; }
        public PersonalTraining PersonalTrainingSession { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public Diet Diet { get; set; }
        public Supplement Supplement { get; set; }
        public TrainingEquipment TrainingEquipment { get; set; }
        public Order Order { get; set; }


        // Order Details
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}

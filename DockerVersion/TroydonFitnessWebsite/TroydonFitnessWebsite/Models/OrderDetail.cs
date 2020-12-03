using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitnessWebsite.Models.Products
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        // foreign keys
        public int? TrainingRoutineID { get; set; }
        public int? DietID { get; set; }
        public int? SupplementID { get; set; }
        public int? TrainingEquipmentID { get; set; }
        public string PurchaserID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }


        // Navigation properties
        public Product Product { get; set; }
        public Order Order { get; set; }
        public TrainingRoutine TrainingRoutine { get; set; }
        public Diet Diet { get; set; }
        public Supplement Supplement { get; set; }
        public TrainingEquipment TrainingEquipment { get; set; }
        // 
        public string ProductName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? OrderNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd hh:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Order Updated")]
        public DateTime OrderUpdated { get; set; }
        public int CurrentOrderItemNumber { get; set; }
        [Display(Name = "Personal Training Session Type")]
        public PersonalTraining.SessionType PTSessionType { get; internal set; }

        [Display(Name = "Routine Length. Duration in days")]
        public int LengthOfRoutine { get; internal set; }

        [Display(Name = "Difficulty Level")]
        public PersonalTraining.Difficulty ExperienceLevel { get; internal set; }
    }
}

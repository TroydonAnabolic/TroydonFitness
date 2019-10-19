using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TroydonFitness.Models.Products
{
    public class Product
    {
        //private string _key { get; set; }
        //public string Key
        //{
        //    get
        //    {
        //        if (_key == null)
        //        {
        //            _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
        //        }
        //        return _key;
        //    }
        //    set { _key = value; }
        //}

        // Primary Key
        public int ProductID { get; set; }

        // Foreign Key
        public int PersonalTrainingId { get; set; }

        // Navigation Properties
        public PersonalTraining PersonalTrainingSessions { get; set; }
        public  ICollection<Supplement> Supplements { get; set; }
        public ICollection<CustomizedRoutine> CustomizedRoutines { get; set; }
        public ICollection<Diet> Diets { get; set; }
        public ICollection<TrainingEquipment> TrainingEquipments { get; set; }


        // Product Details
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public Availability HasStock { get; set; }

        public enum Availability
        {
            Available,
            Unavailable,
            ComingSoon
        }

        // TO use later for Identity User
        public string Person { get; set; }
        public string Administrator { get; set; }


    }
}

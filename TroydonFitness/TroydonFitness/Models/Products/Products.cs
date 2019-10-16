using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TroydonFitness.Models.Products
{
    public class Products
    {
        private string _key { get; set; }
        public string Key
        {
            get
            {
                if (_key == null)
                {
                    _key = Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-");
                }
                return _key;
            }
            set { _key = value; }
        }

        // Primary Key
        public int ProductID { get; set; }

        // Foreign Key
        public int SupplementID { get; set; }
        public int CustomizedRoutineID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }

        // Navigation Properties
        public virtual ICollection<Supplement> Supplements { get; set; }
        public ICollection<CustomizedRoutine> CustomizedRoutines { get; set; }


        [ForeignKey(nameof(Product))]
        public Products Product { get; set; }
        public Supplement Supplement { get; set; }
        public CustomizedRoutine customizedRoutine { get; set; }
        //public string Url { get; set; }

        public bool HasStock { get; set; }
        public string Person { get; set; }
        public string Administrator { get; set; }


    }
}

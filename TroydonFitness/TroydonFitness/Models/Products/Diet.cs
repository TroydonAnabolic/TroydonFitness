namespace TroydonFitness.Models.Products
{
    public class Diet 
    {
        // Keys
        public int DietID { get; set; }
        public int ProductID { get; set; }

        // Navigation
        public Product Product { get; internal set; }

        // Details
        public Type DietType { get; set; }

        public enum Type
        {
            looseWeight,
            gainMuscle,
        }
    }
}
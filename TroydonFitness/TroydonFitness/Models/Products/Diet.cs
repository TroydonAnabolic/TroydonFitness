namespace TroydonFitness.Models.Products
{
    public class Diet 
    {
        public int DietID { get; set; }

        public int ProductID { get; set; }

        public Type DietType { get; set; }
        public Product Product { get; internal set; }

        public enum Type
        {
            looseWeight,
            gainMuscle,
        }
    }
}
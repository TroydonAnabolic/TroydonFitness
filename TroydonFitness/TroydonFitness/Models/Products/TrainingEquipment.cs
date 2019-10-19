namespace TroydonFitness.Models.Products
{
    public class TrainingEquipment 
    {
        // Keys
        public int TrainingEquipmentID { get; set; }
        public int ProductID { get; set; }

        // Navigation
        public Product Product { get; set; }


        // Details
        public Type EquipmentType { get; set; }

        public enum Type
        {
            Belt,
            Strap,
            Band,
            Hooks
        }
    }
}
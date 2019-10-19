namespace TroydonFitness.Models.Products
{
    public class TrainingEquipment 
    {
        public int TrainingEquipmentID { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }

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
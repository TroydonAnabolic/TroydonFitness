using static TroydonFitnessWebsite.Models.Products.Product;

namespace TroydonFitnessWebsite.Models.UserAccounts
{
    //  displays how many products have certain training routine lengths, their type of sessions and experience
    public class Diagnostic
    {
        public int ProductCount { get; set; }
        public Availability HasStock { get; set; }
    }
}

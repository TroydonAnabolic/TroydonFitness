using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TroydonFitness.Models.Products
{
    public class Products
    {

        public int ProductId { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public List<PersonalTraining> OnlinePersonalTrainingSessions { get; set; }
        public List<PersonalTraining> PersonalTrainingSessions { get; set; }
        public List<CustomizedRoutine> CustomizedRoutines { get; set; }
        public List<Diet> Diets { get; set; }
        public List<Supplement> Supplements { get; set; }
        public List<TrainingEquipment> TrainingEquipments { get; set; }

    }
}

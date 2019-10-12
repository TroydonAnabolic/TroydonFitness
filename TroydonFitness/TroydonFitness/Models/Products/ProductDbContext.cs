using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TroydonFitness.Models.Products
{
    public class ProductDbContext : DbContext
    {
        public DbSet<PersonalTraining> OnlinePersonalTrainingSessions { get; set; }
        public DbSet<PersonalTraining> PersonalTrainingSessions { get; set; }
        public DbSet<CustomizedRoutine> CustomizedRoutines { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipments { get; set; }
    }
}

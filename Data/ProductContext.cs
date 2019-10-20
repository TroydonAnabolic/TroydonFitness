using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TroydonFitness.Models.ProductModel;

namespace TroydonFitness.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<CustomizedRoutine> CustomizedRoutines { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipments { get; set; }
        // public DbSet<SupplementRoutine> SupplementRoutines { get; set; }
        public DbSet<PersonalTraining> PersonalTrainingSessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<CustomizedRoutine>().ToTable("CustomizedRoutine");
            modelBuilder.Entity<Supplement>().ToTable("Supplement");
            modelBuilder.Entity<Diet>().ToTable("Diet");
            modelBuilder.Entity<PersonalTraining>().ToTable("PersonalTraining");
            modelBuilder.Entity<TrainingEquipment>().ToTable("TrainingEquipment");
        }
    }
}

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



            // Fluent API to define Entity Relationships one-to-many
            //modelBuilder.Entity<Product>()
            //    .HasMany<Supplement>(s => s.Supplements)
            //    .WithOne(p => p.Product)
            //    .HasForeignKey(s => s.ProductID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<Product>()
            //    .HasMany<CustomizedRoutine>(c => c.CustomizedRoutines)
            //    .WithOne(p => p.Product)
            //    .HasForeignKey(c => c.ProductID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Product>()
            //    .HasMany<Diet>(d => d.Diets)
            //    .WithOne(p => p.Product)
            //    .HasForeignKey(d => d.ProductID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);


            //modelBuilder.Entity<Product>()
            //    .HasMany<TrainingEquipment>(e => e.TrainingEquipments)
            //    .WithOne(p => p.Product)
            //    .HasForeignKey(s => s.ProductID)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<PersonalTraining>()
            //    .HasMany<Product>(p => p.Products)
            //    .WithOne(pt => pt.PersonalTrainingSessions)
            //    .HasForeignKey(p => p.PersonalTrainingId)
            //    .IsRequired(false)
            //    .OnDelete(DeleteBehavior.Restrict);

            // Many-to-Many Relationships definition
            modelBuilder.Entity<SupplementRoutine>()
                .HasKey(sr => new { sr.SupplementId, sr.CustomizedRoutineId });
            modelBuilder.Entity<SupplementRoutine>()
                .HasOne(sr => sr.Supplement)
                .WithMany(s => s.SupplementRoutines)
                .HasForeignKey(sr => sr.SupplementId)
                .IsRequired(false);
            modelBuilder.Entity<SupplementRoutine>()
                .HasOne(sr => sr.CustomizedRoutine)
                .WithMany(c => c.SupplementRoutines)
                .HasForeignKey(sr => sr.CustomizedRoutineId)
                .IsRequired(false);
        }
    }
}

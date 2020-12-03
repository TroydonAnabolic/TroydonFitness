using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Data
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplement> Supplements { get; set; }
        public DbSet<Diet> Diets { get; set; }
        public DbSet<PersonalTraining> PersonalTrainingSessions { get; set; }
        public DbSet<TrainingRoutine> TrainingRoutines { get; set; }
        public DbSet<TrainingEquipment> TrainingEquipmentPurchases { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Cart> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Supplement>().ToTable("Supplement");
            modelBuilder.Entity<Diet>().ToTable("Diet");
            modelBuilder.Entity<PersonalTraining>().ToTable("PersonalTraining");
            modelBuilder.Entity<TrainingRoutine>().ToTable("TrainingRoutine");
            modelBuilder.Entity<TrainingEquipment>().ToTable("TrainingEquipment");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Cart>().ToTable("Cart");

            // Configured relationship to avoid FK constraint when updating
            modelBuilder.Entity<PersonalTraining>()
                .HasOne(x => x.Product)
                .WithMany(x => x.PersonalTrainingSessions)
                .HasForeignKey(x => x.ProductID);

            modelBuilder.Entity<Diet>()
              .HasMany(x => x.Orders)
              .WithOne(x => x.Diet)
              .HasForeignKey(x => x.DietID);

            modelBuilder.Entity<TrainingRoutine>()
              .HasMany(x => x.Orders)
              .WithOne(x => x.TrainingRoutine)
              .HasForeignKey(x => x.TrainingRoutineID);

            modelBuilder.Entity<Supplement>()
              .HasMany(x => x.Orders)
              .WithOne(x => x.Supplement)
              .HasForeignKey(x => x.SupplementID);

            modelBuilder.Entity<TrainingEquipment>()
              .HasMany(x => x.Orders)
              .WithOne(x => x.TrainingEquipment)
              .HasForeignKey(x => x.TrainingEquipmentID);

            modelBuilder.Entity<Order>()
                .HasKey(x => x.OrderID);

            modelBuilder.Entity<OrderDetail>()
               .HasKey(x => x.OrderDetailID);

            modelBuilder.Entity<OrderDetail>()
               .HasOne(x => x.Order)
               .WithMany(x => x.OrderDetails)
               .HasForeignKey(x => x.OrderID);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
        {
            // Updates the last updated property value each time we add new products
            var AddedEntitiesProd = ChangeTracker.Entries<Product>().Where(E => E.State == EntityState.Added).ToList();

            AddedEntitiesProd.ForEach(E =>
            {
                E.Entity.LastUpdated = DateTime.Now;
            });

            var EditedEntitiesProd = ChangeTracker.Entries<Product>().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntitiesProd.ForEach(E =>
            {
                E.Entity.LastUpdated = DateTime.Now;
            });

            // Updates the last updated property value each time we add new orders or update it

            var AddedEntitiesOrder = ChangeTracker.Entries<Order>().Where(E => E.State == EntityState.Added).ToList();

            AddedEntitiesOrder.ForEach(E =>
            {
                E.Entity.OrderDate = DateTime.Now;
            });

            var EditedEntitiesOrder = ChangeTracker.Entries<Order>().Where(E => E.State == EntityState.Modified).ToList();

            EditedEntitiesOrder.ForEach(E =>
            {
                E.Entity.OrderUpdated = DateTime.Now;
            });


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        // Updates the last updated property value each time we add new products

    }
}

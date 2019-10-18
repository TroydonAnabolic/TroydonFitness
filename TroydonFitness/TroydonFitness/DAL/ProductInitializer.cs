using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TroydonFitness.Models.Products;

namespace TroydonFitness.DAL
{
    public static class ProductInitializer 
    {
        // May need to correct seed statement
        public static void Initialize(ProductDbContext context)
        {
           // context.Database.EnsureDeleted(); //may need to add to drop database first to add new schema

            context.Database.EnsureCreated();

            // Look for any CustomizedRoutines.
            if (context.CustomizedRoutines.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
{
                new Product{Title="Strength", Description="Gain Mass", Price=100, Quantity=1002 },
                new Product{Title="Ultra Saiyan", Description="Build muscle and transform to supersaiyan", Price=150, Quantity=5002 },
                new Product{Title="Marathon Runner", Description="Get endurance you need", Price=70, Quantity=1502 },
                new Product{Title="Get started", Description="Begin muscle journey", Price=50, Quantity=806 },
                new Product{Title="Improve Fitness", Description="General fitness levels improvement", Price=100, Quantity=1002 },
                new Product{Title="Endure and Build", Description="Build lean muscle nad keep lean", Price=80, Quantity=902 },
                new Product{Title="Strength", Description="Gain Strength", Price=100, Quantity=1002 },
};
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var routines = new CustomizedRoutine[]
            { // May have to make supp ID match product ID correctly
                new CustomizedRoutine{RoutineType="Endurance", DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=3,ProductID=1050},
                new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=5,ProductID=4022},
                new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Intermediate,RoutineAdded=DateTime.Parse("2018-09-01"),SupplementID=5,ProductID=4041},
                new CustomizedRoutine{RoutineType="Endurance",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=6,ProductID=1045},
                new CustomizedRoutine{RoutineType="Beginner",DifficultyLevel=CustomizedRoutine.Difficulty.Advanced,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=4,ProductID=3141},
                new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2016-09-01"),SupplementID=3,ProductID=1050},
                new CustomizedRoutine{RoutineType="Hypertrophy",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2018-09-01"),SupplementID=2,ProductID=4022},
                new CustomizedRoutine{RoutineType="Hypertrophy",DifficultyLevel=CustomizedRoutine.Difficulty.Intermediate,RoutineAdded=DateTime.Parse("2019-09-01"),SupplementID=3,ProductID=4041}
            };
            foreach (CustomizedRoutine CR in routines)
            {
                context.CustomizedRoutines.Add(CR);
            }
            context.SaveChanges();



            var supplements = new Supplement[]
            {
                new Supplement{CustomizedRoutineID=1,ProductID=1050},
                new Supplement{CustomizedRoutineID=1,ProductID=4022},
                new Supplement{CustomizedRoutineID=1,ProductID=4041},
                new Supplement{CustomizedRoutineID=2,ProductID=1045},
                new Supplement{CustomizedRoutineID=2,ProductID=3141},
                new Supplement{CustomizedRoutineID=2,ProductID=2021},
                new Supplement{CustomizedRoutineID=3,ProductID=1050},
                new Supplement{CustomizedRoutineID=4,ProductID=1050},
                new Supplement{CustomizedRoutineID=4,ProductID=4022},
                new Supplement{CustomizedRoutineID=5,ProductID=4041},
                new Supplement{CustomizedRoutineID=6,ProductID=1045},
                new Supplement{CustomizedRoutineID=7,ProductID=3141},
            };
            foreach (Supplement s in supplements)
            {
                context.Supplements.Add(s);
            }
            context.SaveChanges();
        }

    }
}
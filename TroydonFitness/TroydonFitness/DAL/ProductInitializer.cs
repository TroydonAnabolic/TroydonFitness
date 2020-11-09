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
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                // Strength routines
                new Product{
                    //PersonalTrainingId = 1,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=70, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                    //PersonalTrainingId = 2,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                    //PersonalTrainingId = 3,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=110, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                // Hypertrophy routines
                new Product{
                    //PersonalTrainingId = 4,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=75, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                    PersonalTrainingId = 5,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                    //PersonalTrainingId = 6,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=120, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                // Endurance routines
                new Product{
                    //PersonalTrainingId = 7,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                    //PersonalTrainingId = 8,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
                new Product{
                   // PersonalTrainingId = 9,
                    Title="Easy Stregth Starter Routine", Description="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available, Person = "Troy", Administrator = "Troydon",
                    },
            };
            foreach (Product p in products)
            {
                context.Products.Add(p);
            }
            context.SaveChanges();

            var ptSessions = new PersonalTraining[]
            {
                    // Strength Sessions
                    new PersonalTraining {
                        PersonalTrainingID = 1,
                        PTTitle = "Easy Stregth Starter Routine", PTSessionName = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their strength," +
                        "max training duration is 30 minutes.",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 2,
                        PTTitle = "Strength for the trained", PTSessionName = PersonalTraining.SessionType.Strength,ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their strength tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 3,
                        PTTitle = "Super Heavy Lifter", PTSessionName = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice powerlifting some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },

                    // Hypertrophy Sessions
                    new PersonalTraining {
                        PersonalTrainingID = 4,
                        PTTitle = "Time to grow muscle", PTSessionName = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the fitness industry and want to increase their muscle level," +
                        "max training duration is 30 minutes.",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 5,
                        PTTitle = "Hydro muscle builder", PTSessionName = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 6,
                        PTTitle = "Super muscle bodybuilding", PTSessionName = PersonalTraining.SessionType.Hypertrophy,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                        
                    }, 

                    // Endurance Sessions
                    new PersonalTraining {
                        PersonalTrainingID = 7,
                        PTTitle = "Runner Starter", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description = "This routine is great for those that are new to the running," +
                        "",
                        WorkoutLength = new TimeSpan(0, 30, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 8,
                        PTTitle = "Long distance runner", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description = "This routine is great for those that have some experience in training and are looking at increasing their endurance tier",
                        WorkoutLength = new TimeSpan(0, 45, 00),
                    },
                    new PersonalTraining {
                        PersonalTrainingID = 9,
                        PTTitle = "Marathon Endurance", PTSessionName = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description = "This routine is great for those that have a lot of experience and are interested in being highly trained with long distance" +
                        " model or bodybuilding some time.",
                        WorkoutLength = new TimeSpan(0, 60, 00),
                    },
            };
            foreach (PersonalTraining pt in ptSessions)
            {
                context.PersonalTrainingSessions.Add(pt);
            }
            context.SaveChanges();



            //var routines = new CustomizedRoutine[]
            //{ // May have to make supp ID match product ID correctly
            //    new CustomizedRoutine{RoutineType="Endurance", DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=3,ProductID=1050},
            //    new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=5,ProductID=4022},
            //    new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Intermediate,RoutineAdded=DateTime.Parse("2018-09-01"),SupplementID=5,ProductID=4041},
            //    new CustomizedRoutine{RoutineType="Endurance",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=6,ProductID=1045},
            //    new CustomizedRoutine{RoutineType="Beginner",DifficultyLevel=CustomizedRoutine.Difficulty.Advanced,RoutineAdded=DateTime.Parse("2019-10-17"),SupplementID=4,ProductID=3141},
            //    new CustomizedRoutine{RoutineType="Strength",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2016-09-01"),SupplementID=3,ProductID=1050},
            //    new CustomizedRoutine{RoutineType="Hypertrophy",DifficultyLevel=CustomizedRoutine.Difficulty.Beginner,RoutineAdded=DateTime.Parse("2018-09-01"),SupplementID=2,ProductID=4022},
            //    new CustomizedRoutine{RoutineType="Hypertrophy",DifficultyLevel=CustomizedRoutine.Difficulty.Intermediate,RoutineAdded=DateTime.Parse("2019-09-01"),SupplementID=3,ProductID=4041}
            //};
            //foreach (CustomizedRoutine CR in routines)
            //{
            //    context.CustomizedRoutines.Add(CR);
            //}
            //context.SaveChanges();



            //    var supplements = new Supplement[]
            //    {
            //        new Supplement{CustomizedRoutineID=1,ProductID=1050},
            //        new Supplement{CustomizedRoutineID=1,ProductID=4022},
            //        new Supplement{CustomizedRoutineID=1,ProductID=4041},
            //        new Supplement{CustomizedRoutineID=2,ProductID=1045},
            //        new Supplement{CustomizedRoutineID=2,ProductID=3141},
            //        new Supplement{CustomizedRoutineID=2,ProductID=2021},
            //        new Supplement{CustomizedRoutineID=3,ProductID=1050},
            //        new Supplement{CustomizedRoutineID=4,ProductID=1050},
            //        new Supplement{CustomizedRoutineID=4,ProductID=4022},
            //        new Supplement{CustomizedRoutineID=5,ProductID=4041},
            //        new Supplement{CustomizedRoutineID=6,ProductID=1045},
            //        new Supplement{CustomizedRoutineID=7,ProductID=3141},
            //    };
            //    foreach (Supplement s in supplements)
            //    {
            //        context.Supplements.Add(s);
            //    }
            //    context.SaveChanges();
            //}

        }
    }
}
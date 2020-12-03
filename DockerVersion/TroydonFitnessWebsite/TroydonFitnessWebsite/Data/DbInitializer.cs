using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TroydonFitnessWebsite.Data;
using TroydonFitnessWebsite.Models;
using TroydonFitnessWebsite.Models.Products;

namespace TroydonFitnessWebsite.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ProductContext context)
        {
            //context.Database.EnsureCreated();

            // Look for any CustomizedRoutines.
            if (context.Products.Any())
            {
                return;   // DB has been seeded
            }

            var products = new Product[]
            {
                // Strength routines
                new Product{
                    Title="Beginner Stregth Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=70, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    Title="Intermediate Stregth Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    Title="Advanced Stregth  Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=110, Quantity=3, HasStock = Product.Availability.Available,
                    },
                // Hypertrophy routines
                new Product{
                    Title="Beginner Hypertrophy Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=75, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{

                    Title="Intermediate Hypertrophy Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=90, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    Title="Advanced Hypertrophy Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=120, Quantity=3, HasStock = Product.Availability.Available,
                    },
                // Endurance routines
                new Product{
                    Title="Beginner Endurance Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    Title="Intermediate Endurance Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
                new Product{
                    Title="Advanced Endurance Routine", ShortDescription ="This routine is great for those that are new to the fitness industry and want to increase their strength",
                    Price=100, Quantity=3, HasStock = Product.Availability.Available,
                    },
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var ptSessions = new PersonalTraining[]
            {
                    // Strength Sessions
                    new PersonalTraining {
                        ProductID = 1,
                        PersonalTrainingName = "Beginner Stregth Starter Routine",
                        PTSessionType = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description  = "This routine is great for those that are new to the fitness industry and want to increase their strength," +
                        "max training duration is 30 minutes.",
                        LengthOfRoutine = 30,
                       PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/beginner-strength.jpg"), //TODO: Set these defaults to be proper image defaults, also make default img on create training rotine
                        IsFeatured= true,

                     },
                    new PersonalTraining {
                        ProductID = 2,
                        PersonalTrainingName = "Intermediate Stregth Routine",
                         PTSessionType = PersonalTraining.SessionType.Strength,ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description  = "This routine is great for those that have some experience in training and are looking at increasing their strength tier",
                        LengthOfRoutine = 60,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/intermediate-strength.jpg"),
                        IsFeatured= false,
                    },
                    new PersonalTraining {
                        ProductID = 3,
                        PersonalTrainingName = "Advanced Stregth Routine",
                        PTSessionType = PersonalTraining.SessionType.Strength, ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description  = "This routine is great for those that have a lot of experience and are interested in competing in novice powerlifting some time.",
                        LengthOfRoutine = 90,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/advanced-strength.jpg"),
                        IsFeatured= true,
                    },

                    // Hypertrophy Sessions
                    new PersonalTraining {
                        ProductID = 4,
                        PersonalTrainingName = "Beginner Hypertrophy Routine",
                        PTSessionType = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description  = "This routine is great for those that are new to the fitness industry and want to increase their muscle level," +
                        "max training duration is 30 minutes.",
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/beginner-hypertrophy.jpg"),
                        LengthOfRoutine = 30,
                        IsFeatured= true,
                    },
                    new PersonalTraining {
                        ProductID = 5,
                        PersonalTrainingName = "Intermediate Hypertrophy Routine",
                        PTSessionType = PersonalTraining.SessionType.Hypertrophy, ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description  = "This routine is great for those that have some experience in training and are looking at increasing their muscle tier",
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/intermediate-hypertrophy.jpg"),
                        LengthOfRoutine = 60,
                        IsFeatured= false,
                    },
                    new PersonalTraining {
                        ProductID = 6,
                        PersonalTrainingName = "Advanced Hypertrophy Routine",
                        PTSessionType = PersonalTraining.SessionType.Hypertrophy,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description  = "This routine is great for those that have a lot of experience and are interested in competing in novice fitness" +
                        " model or bodybuilding some time.",
                        LengthOfRoutine = 90,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/advanced-hypertrophy.jpg"),
                        IsFeatured= true,
                    }, 

                    // Endurance Sessions
                    new PersonalTraining {
                        ProductID = 7,
                        PersonalTrainingName = "Beginner Endurance Routine",
                        PTSessionType = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Beginner,
                        Description  = "This routine is great for those that are new to the running," +
                        "",
                        LengthOfRoutine = 30,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/beginner-endurance.jpg"),
                        IsFeatured= false,
                    },
                    new PersonalTraining {
                        ProductID = 8,
                        PersonalTrainingName = "Intermediate Endurance Routine",
                        PTSessionType = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Intermediate,
                        Description  = "This routine is great for those that have some experience in training and are looking at increasing their endurance tier",
                        LengthOfRoutine = 60,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/intermediate-endurance.jpg"),
                        IsFeatured= false,
                    },
                    new PersonalTraining {
                        ProductID = 9,
                        PersonalTrainingName = "Advanced Endurance Routine",
                        PTSessionType = PersonalTraining.SessionType.Endurance,
                        ExperienceLevel = PersonalTraining.Difficulty.Advanced,
                        Description  = "This routine is great for those that have a lot of experience and are interested in being highly trained with long distance" +
                        " model or bodybuilding some time.",
                        LengthOfRoutine = 90,
                        PtProductPicture = File.ReadAllBytes(@"D:/Troydon/Documents/IT_Project/TroydonFitness/DockerVersion/TroydonFitnessWebsite/TroydonFitnessWebsite/wwwroot/images/advanced-endurance.jpg"),
                        IsFeatured= true,
                    },
            };
            context.PersonalTrainingSessions.AddRange(ptSessions);
            context.SaveChanges();

            var trainingRoutines = new TrainingRoutine[]
            {
                // adds a list string and converts to string in intialize TODO: will need to find a way to do the convert when adding to the DB
                new TrainingRoutine{PersonalTrainingID = 3,  DailyAvailability =  string.Join(",", new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }), },
                new TrainingRoutine{PersonalTrainingID = 4,  DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", }),     },
                new TrainingRoutine{PersonalTrainingID = 5 , DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }),    },
                new TrainingRoutine{PersonalTrainingID = 6 , DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }),    },
                new TrainingRoutine{PersonalTrainingID = 7 , DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }),    },
                new TrainingRoutine{PersonalTrainingID = 8 , DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }),    },
                new TrainingRoutine{PersonalTrainingID = 9 , DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday",  }),    },
                new TrainingRoutine{PersonalTrainingID = 11, DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday", }),    },
                new TrainingRoutine{PersonalTrainingID = 12, DailyAvailability = string.Join(",", new List<string>() {  "Monday", "Tuesday", "Wednesday", "Thursday", "Friday",  }),    },
            };

            context.TrainingRoutines.AddRange(trainingRoutines);
            context.SaveChanges();

            //// Seeding the add order details
            //var order = new Order[]
            //{ 
            //    new Order{ Customer = "Troydon Luicien", Quantity = 1, Price = 100, TrainingRoutineID = 3, },
            //    new Order{ Customer = "Troydon Luicien", Quantity = 1, Price = 100, TrainingRoutineID = 3, },
            //    new Order{ Customer = "Troydon Luicien", Quantity = 1, Price = 100, TrainingRoutineID = 3, },
            //    new Order{ Customer = "Troydon Luicien", Quantity = 1, Price = 100, TrainingRoutineID = 3, },

            //};


            //context.Orders.AddRange(order);
            ////context.OrderDetails.AddRange(orderDetails);
            //context.SaveChanges();

            var diets = new Diet[]
            {
                new Diet{Description="test  diet test diet", PersonalTrainingID = 1,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 2,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 3,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 4,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 5,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 6,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 7,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" })  },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 8,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" }) },
                new Diet{Description="test  diet test diet", PersonalTrainingID = 9,     PreferredFood = string.Join(",", new List<string>() { "Vegetarian", "Chicken", "Beef", "Eggs", "Nuts", "Other" }) } ,
            };

            context.Diets.AddRange(diets);
            context.SaveChanges();

            var supplements = new Supplement[]
            {
                new Supplement{Description="test supplement"},
                new Supplement{Description="test supplement"},
                new Supplement{Description="test supplement"},

                new Supplement{Description="test supplement"},
                new Supplement{Description="tes supplementt"},
                new Supplement{Description="test supplement"},

                new Supplement{Description="test supplement"},
                new Supplement{Description="test supplement"},
                new Supplement{Description="test supplement"},
            };

            context.Supplements.AddRange(supplements);
            context.SaveChanges();
        }
    }
}
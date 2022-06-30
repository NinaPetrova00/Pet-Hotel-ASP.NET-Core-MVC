using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pet_Hotel.Data;
using System;
using System.Linq;

namespace Pet_Hotel.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Pet_HotelContext(
                serviceProvider.GetRequiredService<DbContextOptions<Pet_HotelContext>>()))
            {
                // Look for any pets.
                if (context.Pet.Any())
                {
                    return;   // DB has been seeded
                }

                context.Pet.AddRange(
                    new Pet
                    {
                        Name = "Charlie",
                        Type = "Dog",
                        Breed = "Poodle",
                        Age = 3,
                        PetOwner = "Ivan",
                        checkedIn = DateTime.Parse("5/1/2022 8:30:52 AM"),
                        checkedOut = DateTime.Parse("7/1/2022 11:30:52 AM")
                    },

                     new Pet
                     {
                         Name = "Tara",
                         Type = "Dog",
                         Breed = "Retriver",
                         Age = 7,
                         PetOwner = "Peter",
                         checkedIn = DateTime.Parse("15/1/2022 7:00:50 PM"),
                         checkedOut = DateTime.Parse("20/1/2022 08:00:08 AM"),
                     },

                     new Pet
                     {
                         Name = "Ayra",
                         Type = "Dog",
                         Breed = "Spitz",
                         Age = 1,
                         PetOwner = "Maria",
                         checkedIn = DateTime.Parse("18/4/2022 5:05:55 PM"),
                         checkedOut = DateTime.Parse("1/2/2022 8:30:25 AM"),
                     },

                    new Pet
                    {
                        Name = "Caroline",
                        Type = "Cat",
                        Breed = "Angora",
                        Age = 6,
                        PetOwner = "Maria",
                        checkedIn = DateTime.Parse("9/6/2022 10:25:59 AM")
                    },

                     new Pet
                     {
                         Name = "Lolla",
                         Type = "Rabbit",
                         Breed = "Dutch",
                         Age = 4,
                         PetOwner = "Stela",
                         checkedIn = DateTime.Parse("19/6/2022 11:55:55 AM")
                     }

                 );
                context.SaveChanges();
            }
        }
    }
}

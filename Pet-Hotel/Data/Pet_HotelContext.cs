using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Pet_Hotel.Models;

namespace Pet_Hotel.Data
{
    public class Pet_HotelContext : DbContext
    {
        public Pet_HotelContext (DbContextOptions<Pet_HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Pet_Hotel.Models.Pet>? Pet { get; set; }

        public DbSet<Pet_Hotel.Models.Review>? Review { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BicycleAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BicycleAPI.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bicycle> Bicycles { get; set; }
        public DbSet<BicycleType> BicycleTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var Type1 = new BicycleType { Id = 1, Name = "Road" };
            var Type2 = new BicycleType { Id = 2, Name = "Mountain" };

            modelBuilder.Entity<BicycleType>().HasData(Type1, Type2);

            modelBuilder.Entity<Bicycle>().HasData(
                new Bicycle { Id = 1, Name = "Bicycle1", BicycleTypeId = Type1.Id, Price = 200m, IsRented = false },
                new Bicycle { Id = 2, Name = "Bicycle2", BicycleTypeId = Type2.Id, Price = 250m, IsRented = false },
                new Bicycle { Id = 3, Name = "Bicycle3", BicycleTypeId = Type2.Id, Price = 230m, IsRented = true },
                new Bicycle { Id = 4, Name = "Bicycle4", BicycleTypeId = Type1.Id, Price = 300m, IsRented = true },
                new Bicycle { Id = 5, Name = "Bicycle5", BicycleTypeId = Type1.Id, Price = 220m, IsRented = false }
                );
        }
    }
}

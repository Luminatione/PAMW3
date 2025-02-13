﻿using Microsoft.EntityFrameworkCore;
using P06Shop.Shared.Cars;
using P07Shop.DataSeeder;

namespace P05Shop.API
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=tcp:p05shopapidbserver.database.windows.net,1433;Initial Catalog=P05Shop.API_db;User Id=postgres@p05shopapidbserver;Password=qwerty123!");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Property(e => e.Power).IsRequired();
            modelBuilder.Entity<Person>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<CarBrand>().Property(e => e.Name).IsRequired();

            modelBuilder.Entity<CarBrand>().HasKey(cb => cb.Id);
            modelBuilder.Entity<CarBrand>().Property(cb => cb.Id).ValueGeneratedOnAdd().UseIdentityAlwaysColumn();

            modelBuilder.Entity<Person>().HasKey(p => p.Id);
            modelBuilder.Entity<Person>().Property(p => p.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>().HasKey(c => c.Id);
            modelBuilder.Entity<Car>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>(Car => Car.HasOne(c => c.CarBrand));

            modelBuilder.Entity<Car>(Car => Car.HasOne(c => c.PreviousOwner));

            modelBuilder.Entity<Person>().HasData(PersonSeeder.GeneratePersonData());
            modelBuilder.Entity<CarBrand>().HasData(CarBrandSeeder.GenerateCarBrandData());
            modelBuilder.Entity<Car>().HasData(CarSeeder.GenerateCarData());

            base.OnModelCreating(modelBuilder);
        }
    }
}

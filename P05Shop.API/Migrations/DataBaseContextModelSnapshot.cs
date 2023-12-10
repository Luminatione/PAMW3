﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using P05Shop.API;

#nullable disable

namespace P05Shop.API.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("P06Shop.Shared.Cars.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarBrandId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Power")
                        .HasColumnType("int");

                    b.Property<int?>("PreviousOwnerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarBrandId");

                    b.HasIndex("PreviousOwnerId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarBrandId = 22,
                            Model = "Bugatti",
                            Power = 1954798937,
                            PreviousOwnerId = 9
                        },
                        new
                        {
                            Id = 2,
                            CarBrandId = 21,
                            Model = "Bugatti",
                            Power = 991154489,
                            PreviousOwnerId = 21
                        },
                        new
                        {
                            Id = 3,
                            CarBrandId = 3,
                            Model = "Lamborghini",
                            Power = 1411729325,
                            PreviousOwnerId = 6
                        },
                        new
                        {
                            Id = 4,
                            CarBrandId = 20,
                            Model = "Mazda",
                            Power = 866930202,
                            PreviousOwnerId = 10
                        },
                        new
                        {
                            Id = 5,
                            CarBrandId = 7,
                            Model = "Cadillac",
                            Power = 554013003,
                            PreviousOwnerId = 24
                        },
                        new
                        {
                            Id = 6,
                            CarBrandId = 22,
                            Model = "Maserati",
                            Power = 949138117,
                            PreviousOwnerId = 23
                        },
                        new
                        {
                            Id = 7,
                            CarBrandId = 1,
                            Model = "Smart",
                            Power = 2029260696,
                            PreviousOwnerId = 18
                        },
                        new
                        {
                            Id = 8,
                            CarBrandId = 8,
                            Model = "Volvo",
                            Power = 966978416,
                            PreviousOwnerId = 10
                        },
                        new
                        {
                            Id = 9,
                            CarBrandId = 12,
                            Model = "Tesla",
                            Power = 165085211,
                            PreviousOwnerId = 9
                        },
                        new
                        {
                            Id = 10,
                            CarBrandId = 21,
                            Model = "Polestar",
                            Power = 1924951637,
                            PreviousOwnerId = 14
                        },
                        new
                        {
                            Id = 11,
                            CarBrandId = 2,
                            Model = "Bentley",
                            Power = 1334382263,
                            PreviousOwnerId = 2
                        },
                        new
                        {
                            Id = 12,
                            CarBrandId = 24,
                            Model = "Mazda",
                            Power = 1240494303,
                            PreviousOwnerId = 19
                        },
                        new
                        {
                            Id = 13,
                            CarBrandId = 24,
                            Model = "Aston Martin",
                            Power = 1891364421,
                            PreviousOwnerId = 25
                        },
                        new
                        {
                            Id = 14,
                            CarBrandId = 11,
                            Model = "Mazda",
                            Power = 214606913,
                            PreviousOwnerId = 6
                        },
                        new
                        {
                            Id = 15,
                            CarBrandId = 10,
                            Model = "Lamborghini",
                            Power = 256742547,
                            PreviousOwnerId = 12
                        },
                        new
                        {
                            Id = 16,
                            CarBrandId = 23,
                            Model = "Fiat",
                            Power = 1499469656,
                            PreviousOwnerId = 5
                        },
                        new
                        {
                            Id = 17,
                            CarBrandId = 8,
                            Model = "Rolls Royce",
                            Power = 1040844130,
                            PreviousOwnerId = 21
                        },
                        new
                        {
                            Id = 18,
                            CarBrandId = 24,
                            Model = "Maserati",
                            Power = 7870134,
                            PreviousOwnerId = 2
                        },
                        new
                        {
                            Id = 19,
                            CarBrandId = 14,
                            Model = "Rolls Royce",
                            Power = 1783272972,
                            PreviousOwnerId = 9
                        },
                        new
                        {
                            Id = 20,
                            CarBrandId = 13,
                            Model = "Bugatti",
                            Power = 1479763268,
                            PreviousOwnerId = 18
                        },
                        new
                        {
                            Id = 21,
                            CarBrandId = 16,
                            Model = "Volkswagen",
                            Power = 682772295,
                            PreviousOwnerId = 1
                        },
                        new
                        {
                            Id = 22,
                            CarBrandId = 15,
                            Model = "Fiat",
                            Power = 1785880164,
                            PreviousOwnerId = 19
                        },
                        new
                        {
                            Id = 23,
                            CarBrandId = 19,
                            Model = "Chrysler",
                            Power = 74386829,
                            PreviousOwnerId = 23
                        },
                        new
                        {
                            Id = 24,
                            CarBrandId = 4,
                            Model = "Volvo",
                            Power = 1374334807,
                            PreviousOwnerId = 9
                        },
                        new
                        {
                            Id = 25,
                            CarBrandId = 10,
                            Model = "Mercedes Benz",
                            Power = 706744980,
                            PreviousOwnerId = 10
                        });
                });

            modelBuilder.Entity("P06Shop.Shared.Cars.CarBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarBrands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jaguar",
                            OriginCountry = "Japan"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Honda",
                            OriginCountry = "Yemen"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Porsche",
                            OriginCountry = "Bermuda"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Chrysler",
                            OriginCountry = "Poland"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Toyota",
                            OriginCountry = "Anguilla"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Hyundai",
                            OriginCountry = "Lesotho"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Jeep",
                            OriginCountry = "Finland"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Fiat",
                            OriginCountry = "Guinea"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Honda",
                            OriginCountry = "Ukraine"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Bugatti",
                            OriginCountry = "Andorra"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Rolls Royce",
                            OriginCountry = "Germany"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Ford",
                            OriginCountry = "Australia"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Cadillac",
                            OriginCountry = "Virgin Islands, British"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Lamborghini",
                            OriginCountry = "Ukraine"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Dodge",
                            OriginCountry = "Solomon Islands"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Porsche",
                            OriginCountry = "Sao Tome and Principe"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Ferrari",
                            OriginCountry = "Netherlands"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Kia",
                            OriginCountry = "Virgin Islands, U.S."
                        },
                        new
                        {
                            Id = 19,
                            Name = "Cadillac",
                            OriginCountry = "Turkmenistan"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Dodge",
                            OriginCountry = "Thailand"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Bentley",
                            OriginCountry = "Djibouti"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Chevrolet",
                            OriginCountry = "Aruba"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Chevrolet",
                            OriginCountry = "Faroe Islands"
                        },
                        new
                        {
                            Id = 24,
                            Name = "BMW",
                            OriginCountry = "Northern Mariana Islands"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Hyundai",
                            OriginCountry = "El Salvador"
                        });
                });

            modelBuilder.Entity("P06Shop.Shared.Cars.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Jody Welch",
                            PhoneNumber = "1-288-867-1127"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Allen Pfannerstill",
                            PhoneNumber = "542.760.3020"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Miranda Stiedemann",
                            PhoneNumber = "1-815-206-8660 x7061"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Angela Wiegand",
                            PhoneNumber = "428.924.1945"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cedric Gaylord",
                            PhoneNumber = "(623) 727-5335"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Becky Crist",
                            PhoneNumber = "(757) 768-8817 x29416"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Cecilia Collier",
                            PhoneNumber = "208-902-5669"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Jorge Ebert",
                            PhoneNumber = "731-984-1561"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Eric Monahan",
                            PhoneNumber = "(656) 689-5335 x9272"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Marc Rowe",
                            PhoneNumber = "248-999-2545"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Rickey Borer",
                            PhoneNumber = "951-749-9846"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Alejandro Greenfelder",
                            PhoneNumber = "(380) 593-4810 x0519"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Kristine Frami",
                            PhoneNumber = "630-401-7646 x97758"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Jeannie Mohr",
                            PhoneNumber = "(425) 672-6787 x18301"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Calvin Weissnat",
                            PhoneNumber = "939-275-6526 x65504"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Ramona Erdman",
                            PhoneNumber = "719.949.1999 x94483"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Dave Gislason",
                            PhoneNumber = "1-770-501-2362"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Robert Witting",
                            PhoneNumber = "753-934-1482 x01292"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Ted Kerluke",
                            PhoneNumber = "908-320-7189 x0777"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Jimmy Boyle",
                            PhoneNumber = "1-677-501-8964"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Luz Klocko",
                            PhoneNumber = "836.971.4523 x325"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Pete Lakin",
                            PhoneNumber = "1-860-390-6697"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Wanda Hoeger",
                            PhoneNumber = "495-653-5319"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Darrin Davis",
                            PhoneNumber = "541-902-0514"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Wendy Witting",
                            PhoneNumber = "727-493-9137"
                        });
                });

            modelBuilder.Entity("P06Shop.Shared.Cars.Car", b =>
                {
                    b.HasOne("P06Shop.Shared.Cars.CarBrand", "CarBrand")
                        .WithMany()
                        .HasForeignKey("CarBrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("P06Shop.Shared.Cars.Person", "PreviousOwner")
                        .WithMany()
                        .HasForeignKey("PreviousOwnerId");

                    b.Navigation("CarBrand");

                    b.Navigation("PreviousOwner");
                });
#pragma warning restore 612, 618
        }
    }
}

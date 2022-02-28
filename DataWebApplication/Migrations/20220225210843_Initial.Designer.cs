﻿// <auto-generated />
using DataWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataWebApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220225210843_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("DataWebApplication.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Boden"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Kiruna"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            Name = "Star City"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = 5,
                            CountryId = 4,
                            Name = "Kiel"
                        });
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sverige"
                        },
                        new
                        {
                            Id = 2,
                            Name = "USA"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Norge"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Tyskland"
                        });
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("Languages");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Svenska"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "Engelska"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Norska"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "Tyska"
                        });
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            CountryId = 1,
                            Name = "Martin",
                            Phone = "0743123456"
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 3,
                            CountryId = 2,
                            Name = "Elon",
                            Phone = "0777622344"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 2,
                            CountryId = 1,
                            Name = "Sven",
                            Phone = "0743124125"
                        },
                        new
                        {
                            PersonId = 4,
                            CityId = 5,
                            CountryId = 4,
                            Name = "Hans",
                            Phone = "0764312345"
                        },
                        new
                        {
                            PersonId = 5,
                            CityId = 4,
                            CountryId = 3,
                            Name = "Björn",
                            Phone = "0777622344"
                        });
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.PersonLanguage", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("PersonId", "LanguageId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PersonLanguages");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            LanguageId = 1,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 2,
                            LanguageId = 2,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 1,
                            LanguageId = 2,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 4,
                            LanguageId = 4,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 5,
                            LanguageId = 3,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 1,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 2,
                            Id = 0
                        },
                        new
                        {
                            PersonId = 3,
                            LanguageId = 3,
                            Id = 0
                        });
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.Property<int>("LanguagesLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsPersonId")
                        .HasColumnType("int");

                    b.HasKey("LanguagesLanguageId", "PersonsPersonId");

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("LanguagePerson");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.City", b =>
                {
                    b.HasOne("DataWebApplication.Models.Entities.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Person", b =>
                {
                    b.HasOne("DataWebApplication.Models.Entities.City", "City")
                        .WithMany("CityPeople")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DataWebApplication.Models.Entities.Country", "Country")
                        .WithMany("CountryPeople")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.PersonLanguage", b =>
                {
                    b.HasOne("DataWebApplication.Models.Entities.Language", "Language")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataWebApplication.Models.Entities.Person", "Person")
                        .WithMany("PersonLanguages")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.HasOne("DataWebApplication.Models.Entities.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguagesLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataWebApplication.Models.Entities.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.City", b =>
                {
                    b.Navigation("CityPeople");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Country", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("CountryPeople");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Language", b =>
                {
                    b.Navigation("PersonLanguages");
                });

            modelBuilder.Entity("DataWebApplication.Models.Entities.Person", b =>
                {
                    b.Navigation("PersonLanguages");
                });
#pragma warning restore 612, 618
        }
    }
}
